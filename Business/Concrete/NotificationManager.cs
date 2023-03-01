using Business.Abstract;
using Business.SignalR;
using Core.Results;
using Core.Results.DataResults;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using Entities.Concrete.Enums;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Business.Concrete
{
  public class NotificationManager : INotificationService
  {
    IHubContext<NotificationsHub> _notificationsHub;
    IDiscussService _discussService;
    IUserService _userService;
    IUserSubjectService _userSubjectService;
    ISubjectService _subjectService;
    INotificationDal _notificationDal;
    public NotificationManager(IHubContext<NotificationsHub> notificationsHub, IDiscussService discussService, IUserService userService, IUserSubjectService userSubjectService, ISubjectService subjectService, INotificationDal notificationDal)
    {

      _notificationDal = notificationDal;
      _discussService = discussService;
      _notificationsHub = notificationsHub;
      _userService = userService;
      _userSubjectService = userSubjectService;
      _subjectService = subjectService;

    }
    public IDataResult<Notification> Add(Notification notification)
    {
      var notify = _notificationDal.Add(notification);
      return new SuccessDataResult<Notification>(notify);

    }

    public IDataResult<List<Notification>> GetAllByUserId(int userId)
    {

      var notifications = _notificationDal.GetAll(x => x.ReceiverId == userId);
      var sendingNotifications = new List<Notification>();

      notifications.ForEach(notification =>
      {
        switch (notification.NotificationType)
        {
          case NotificationTypeEnum.NewReply:
            var firstName = _userService.GetById(notification.TriggeredUserId).Data.FirstName;
            var lastname = _userService.GetById(notification.TriggeredUserId).Data.LastName;
            var currentValue = notification.NotificationValue;
            var currentJson = System.Text.Json.JsonSerializer.Deserialize<IDictionary<string, string>>(currentValue);
            var discussId = int.Parse(currentJson.FirstOrDefault(x => x.Key == "discussId").Value);
            Discuss currentDiscuss;
            try
            {
              currentDiscuss = _discussService.GetById(discussId).Data;
              if(currentDiscuss != null)
              {
                var discussTitle = currentDiscuss.DiscussHeader;
                currentJson.Add("firstName", firstName);
                currentJson.Add("lastName", lastname);
                currentJson.Add("discussTitle", discussTitle);
                notification.NotificationValue = System.Text.Json.JsonSerializer.Serialize(currentJson);
                sendingNotifications.Add(notification);
              }
            }
            catch
            {
              
            }
            break;
        }
      });
      return new SuccessDataResult<List<Notification>>(sendingNotifications);

    }

    public IDataResult<Notification> GetById(int id)
    {
      var notification = _notificationDal.Get(x => x.NotificationId == id);
      return new SuccessDataResult<Notification>(notification);
    }

    public void SendPopNotification(int receiverId, string title, string message, string actionLink = null)
    {
      var notificationDto = new SendNotificationDto();
      notificationDto.ActionLink = actionLink;
      notificationDto.Title = title;
      notificationDto.Message = message;
      _notificationsHub.Clients.User(receiverId.ToString()).SendAsync("PopNotifications", notificationDto);
    }

    public void SendReplyNotification(Reply reply)
    {
      var discussId = reply.DiscussId;
      var senderId = reply.UserId;

      var discuss = _discussService.GetDiscussDetailsByDiscussId(discussId);
      if (senderId == discuss.Data.UserId)
      {
        return;
      }
      var sender = _userService.GetById(senderId);
      var title = "Yeni Yanıt";
      var message = $"{sender.Data.FirstName} {sender.Data.LastName} bir gönderinize yanıt verdi";
      var actionLink = $"/replies/{discussId}";
      SendPopNotification(discuss.Data.UserId, title, message, actionLink);
    }
    public void SendNewDiscussionNotification(Discuss discuss)
    {
      var discussionSubject = discuss.SubjectId;
      var subject = _subjectService.GetById(discussionSubject).Data;
      var userSubjectList = _userSubjectService.GetUserSubjectsBySubjectId(discussionSubject).Data;
      foreach (var userSubject in userSubjectList)
      {
        if (discuss.UserId != userSubject.UserId)
        {
          var message = "Takip ettiğiniz " + subject.SubjectName + " konusuna yeni bir tartışma eklendi";
          SendPopNotification(userSubject.UserId, "Yeni tartışma", message, "discussions/filter/subject/" + discussionSubject);
        }

      }
    }

    public IResult AddReplyNotification(Reply reply)
    {
      var discuss = _discussService.GetDiscussDetailsByDiscussId(reply.DiscussId).Data;
      Notification notification = new Notification();
      notification.SendDate = DateTime.UtcNow;
      notification.NotificationType = NotificationTypeEnum.NewReply;
      notification.ReceiverId = discuss.UserId;
      notification.TriggeredUserId = reply.UserId;
      if(notification.ReceiverId == notification.TriggeredUserId)
      {
        return new SuccessResult();
      }
      notification.NotificationIcon = "reply icon";
      notification.IsRead = false;
      notification.ActionUrl = "/replies/" + reply.DiscussId;
      IDictionary<string, string> json = new Dictionary<string, string>();
      json.Add("discussId", reply.DiscussId.ToString());
      json.Add("replyId", reply.ReplyId.ToString());
      notification.NotificationValue = JsonSerializer.Serialize(json);
      _notificationDal.Add(notification);
      return new SuccessResult();
    }
    public IResult DeleteReplyNotification(Reply reply)
    {
      var discuss = _discussService.GetDiscussDetailsByDiscussId(reply.DiscussId);
      var notifications = _notificationDal.GetAll(x => x.ReceiverId == discuss.Data.UserId && x.TriggeredUserId == reply.UserId && x.NotificationType == NotificationTypeEnum.NewReply);
      notifications.ForEach(notification =>
      {
        var parseJson = JsonSerializer.Deserialize<IDictionary<string, string>>(notification.NotificationValue);
        string replyId;
        parseJson.TryGetValue("replyId", out replyId);
        if (replyId == reply.ReplyId.ToString())
        {
          _notificationDal.Delete(notification);
        }

      });
      return new SuccessResult();
    }
  }
}
