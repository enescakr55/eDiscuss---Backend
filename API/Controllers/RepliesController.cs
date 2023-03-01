using Business.Abstract;
using Core.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RepliesController : ControllerBase
  {
    IReplyService _replyService;
    INotificationService _notificationService;
    public RepliesController(IReplyService replyService, INotificationService notificationService)
    {
      _replyService = replyService;
      _notificationService = notificationService;
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
      return Ok(_replyService.GetAll());
    }
    [HttpGet("getbydiscussid")]
    public IActionResult GetByDiscussId(int id)
    {
      return Ok(_replyService.GetRepliesByDiscussId(id));
    }
    [HttpGet("getbyreplyid")]
    public IActionResult GetByReplyId(int id)
    {
      return Ok(_replyService.GetById(id));
    }
    [Authorize]
    [HttpPost("addReply")]
    public IActionResult AddReply(Reply reply)
    {
      string userIdStr = HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
      int userId = int.Parse(userIdStr);
      reply.UserId = userId;
      reply.CreatedDate = DateTime.Now;
      var addedReply = _replyService.Add(reply);
      _notificationService.AddReplyNotification(addedReply.Data);
      return Ok(addedReply);
    }
    [Authorize]
    [HttpGet("delete")]
    public IActionResult Delete(int id)
    {
      string userIdStr = HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
      int userId = int.Parse(userIdStr);
      var reply = _replyService.GetById(id);
      if(reply.Data.UserId == userId)
      {
        return Ok(_replyService.Delete(id));
      }
      return Ok(new ErrorResult());
      
    }
    [HttpGet("getreplies")]
    public IActionResult GetRepliesByDiscuss(int id)
    {
      return Ok(_replyService.GetReplyDetailsByDiscussId(id));
    }
  }
}
