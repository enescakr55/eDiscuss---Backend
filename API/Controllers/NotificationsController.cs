using Business.Abstract;
using Business.SignalR;
using Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NotificationsController : ControllerBase
  {
    IHubContext<NotificationsHub> _notificationHub;
    IHttpContextHelperService _contextHelperService;
    INotificationService _notificationService;
    public NotificationsController(IHubContext<NotificationsHub> notificationHub, IHttpContextHelperService contextHelperService, INotificationService notificationService)
    {
      _notificationHub = notificationHub;
      _contextHelperService = contextHelperService;
      _notificationService = notificationService;
    }
    [HttpGet("getnotifications")]
    public IActionResult GetNotifications()
    {
      var currentUserId = _contextHelperService.GetUserId();
      var notifications = _notificationService.GetAllByUserId(currentUserId);
      return Ok(notifications);
    }
    [HttpGet("SendNotification")]
    public IActionResult SendNotificationToUser(string userId,string title,string message)
    {
      var notificationDto = new SendNotificationDto();
      notificationDto.ActionLink = "/introduction";
      notificationDto.Title = title;
      notificationDto.Message = message;
      _notificationHub.Clients.User(userId).SendAsync("PopNotifications",notificationDto);
      return Ok();
    }
  }
}
