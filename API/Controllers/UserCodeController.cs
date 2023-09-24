using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserCodeController : ControllerBase
  {
    IUserCodeService _userCodeService;

    public UserCodeController(IUserCodeService userCodeService)
    {
      _userCodeService = userCodeService;
    }

    [HttpGet("GetAllByUserId")]
    public IActionResult GetAllByUserId(int userId)
    {
     var result =  _userCodeService.GetAllByUserId(userId);
      return Ok(result);
    }
    [HttpGet("GetUserCodeDetails")]
    public IActionResult GetUserCodeDetails(int userCodeId){
    var result = _userCodeService.GetUserCodeDetailsByUserCodeId(userCodeId);
    return Ok(result);
    }
  }
}
