using Core.Results;
using Core.Results.DataResults;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public interface INotificationService
  {
    public IDataResult<Notification> Add(Notification notification);
    public IResult AddReplyNotification(Reply reply);
    IResult DeleteReplyNotification(Reply reply);
    public IDataResult<List<Notification>> GetAllByUserId(int userId);
    public IDataResult<Notification> GetById(int id);
    public void SendPopNotification(int receiverId,string title, string message, string actionLink = null);
    public void SendReplyNotification(Reply reply);
    public void SendNewDiscussionNotification(Discuss discuss);

  }
}
