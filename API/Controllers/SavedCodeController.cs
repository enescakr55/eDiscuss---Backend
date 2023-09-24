using Business.Abstract;
using Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SavedCodeController : ControllerBase
  {
    ISavedCodeService _savedCodeService;
    public SavedCodeController(ISavedCodeService savedCodeService)
    {
      _savedCodeService = savedCodeService;
    }
    [HttpPost("add")]
    public IActionResult AddSavedCode(AddSavedCodeDto savedCodeDto){
      var result = _savedCodeService.Add(savedCodeDto);
      return Ok(result);
    }
    [HttpPost("update")]
    public IActionResult UpdateSavedCode(UpdateSavedCodeDto savedCodeDto){
    var result = _savedCodeService.Update(savedCodeDto);
    return Ok(result);
    }
    [HttpGet("get")]
    public IActionResult GetCode(int savedCodeId){
      var result = _savedCodeService.GetCodeById(savedCodeId);
      return Ok(result);
    }
    [HttpGet("getother")]
    public IActionResult GetOther(int savedCodeId){
      var result = _savedCodeService.GetCodeTest(savedCodeId);
      return Ok(result);
    }
  }
}
