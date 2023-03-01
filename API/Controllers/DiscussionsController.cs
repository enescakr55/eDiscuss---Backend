using Business.Abstract;
using Core.Results;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DiscussionsController : ControllerBase
  {
    IDiscussService _discussService;
    ISubjectService _subjectService;
    INotificationService _notificationService;
    public DiscussionsController(IDiscussService discussService,ISubjectService subjectService, INotificationService notificationService)
    {
      _discussService = discussService;
      _subjectService = subjectService;
      _notificationService = notificationService;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
      return Ok(_discussService.GetAll());
    }
    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
      return Ok(_discussService.GetById(id));
    }
    [Authorize]
    [HttpPost("addDiscuss")]
    public IActionResult AddDiscuss(Discuss discuss)
    {
      string userIdStr = HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
      int userId = int.Parse(userIdStr);
      discuss.UserId = userId;
      discuss.CategoryId = _subjectService.GetById(discuss.SubjectId).Data.CategoryId;
      discuss.CreatedDate = DateTime.Now;
      var createdDiscuss = _discussService.Add(discuss);
      if (createdDiscuss.Success)
      {
        _notificationService.SendNewDiscussionNotification(createdDiscuss.Data);
      }
      return Ok(createdDiscuss);
    }
    [Authorize]
    [HttpGet("delete")]
    public IActionResult Delete(int id)
    {
      string userIdStr = HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
      int userId = int.Parse(userIdStr);
      var discuss = _discussService.GetById(id).Data;
      if (discuss.UserId == userId)
      {
        return Ok(_discussService.Delete(id));
      }
      return Ok(new ErrorResult());
    }
    [HttpGet("getbysubjectid")]
    public IActionResult GetBySubjectId(int id)
    {
      string userIdStr = HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
      int userId = int.Parse(userIdStr);
      var discuss = _discussService.GetById(id).Data;
      if(discuss.UserId == userId)
      {
        return Ok(_discussService.GetBySubjectId(id));
      }
      return Ok(new ErrorResult());
      
    }
    [Authorize]
    [HttpGet("getdiscussdetails")]
    public IActionResult GetDiscussDetails(int page=0)
    {
      return Ok(_discussService.GetDiscussDetails(page));
    }
    [HttpGet("getdiscussdetailsbyid")]
    public IActionResult GetDiscussDetailsById(int id)
    {
      return Ok(_discussService.GetDiscussDetailsByDiscussId(id));
    }
    [HttpGet("getdiscussdetailsbysubjectid")]
    public IActionResult  GetDiscussDetailsBySubjectId(int subjectid,int page=0)
    {
      return Ok(_discussService.GetDiscussDetailsBySubjectId(subjectid,page));
    }
    [Authorize]
    [HttpGet("getmydiscussions")]
    public IActionResult GetMyDiscussionDetails()
    {
      string userIdStr = HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
      int userId = int.Parse(userIdStr);
      var details = _discussService.GetDiscussDetailsByUserId(userId);
      return Ok(details);
    }
    [Authorize]
    [HttpGet("getuserdiscussions")]
    public IActionResult GetUserDiscussions(string username)
    {
      var details = _discussService.GetDiscussDetailsByUsername(username);
      return Ok(details);
    }
    [Authorize]
    [HttpGet("interestingdiscussions")]
    public IActionResult GetIntrestingDiscussions()
    {
      string userIdStr = HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
      int userId = int.Parse(userIdStr);
      var discussions = _discussService.GetMyInterestingDiscuss(userId);
      return Ok(discussions);
    }
    [Authorize]
    [HttpPost("filterDiscussions")]
    public IActionResult GetFilteredDiscuss(DiscussFilterDto dfo)
    {
      string userIdStr = HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
      int userId = int.Parse(userIdStr);
      var result = _discussService.GetFilteredDiscuss(dfo, userId);
      return Ok(result);
    }
  }
}
