using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SubjectsController : ControllerBase
  {
    ISubjectService _subjectService;
    public SubjectsController(ISubjectService subjectService)
    {
      _subjectService = subjectService;
    }
    [HttpGet("getsubjects")]
    public IActionResult GetSubjects()
    {
      return Ok(_subjectService.GetAll());
    }
    [HttpGet("getbycategoryid")]
    public IActionResult GetByCategoryId(int categoryId)
    {
      return Ok(_subjectService.GetByCategoryId(categoryId));
    }
    [Authorize(Roles = "admin")]
    [HttpPost("addsubject")]
    public IActionResult AddSubject(Subject subject)
    {
      return Ok(_subjectService.Add(subject));
    }
    [Authorize(Roles = "admin")]
    [HttpPost("deletesubject")]
    public IActionResult DeleteSubject(Subject subject)
    {
      return Ok(_subjectService.Delete(subject));
    }
    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
      return Ok(_subjectService.GetById(id));
    }
    [HttpGet("getcategorysubjects")]
    public IActionResult GetCategorySubjects()
    {
      return Ok(_subjectService.GetCategorySubjects());
    }
    [HttpGet("getmycategorysubjects")]
    public IActionResult GetMyCategorySubjects()
    {
      string userIdStr = HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
      int userId = int.Parse(userIdStr);
      var subjectList = _subjectService.GetMyCategorySubjects(userId);
      var a = 0;
      return Ok(subjectList);
    }

  }
}
