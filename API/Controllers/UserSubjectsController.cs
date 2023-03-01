using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserSubjectsController : ControllerBase
  {
    IUserSubjectService _userSubjectService;
    public UserSubjectsController(IUserSubjectService userSubjectService)
    {
      _userSubjectService = userSubjectService;
    }
    [HttpGet("addinteresting")]
    public IActionResult AddInteresting(int subjectid)
    {
      var userId = int.Parse(HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value);
      var userSubject = new UserSubject { SubjectId = subjectid, UserId = userId };
      return Ok(_userSubjectService.Add(userSubject));
    }
    [HttpGet("deleteinteresting")]
    public IActionResult DeleteInteresting(int subjectid)
    {
      var userId = int.Parse(HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value);
      var userSubject = _userSubjectService.GetByUserAndSubjectId(userId, subjectid);
      return Ok(_userSubjectService.Delete(userSubject.Data));

    }
  }
}
