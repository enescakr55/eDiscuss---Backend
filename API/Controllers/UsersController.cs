using Business.Abstract;
using Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    IUserService _userService;
    IWebHostEnvironment _env;
    public UsersController(IUserService userService,IWebHostEnvironment env)
    {
      _userService = userService;
      _env = env;
    }
    [HttpGet("getuserinfo")]
    public IActionResult GetUserInfo(string username)
    {
      return Ok(_userService.GetUserInfoByUsername(username));
    }
    [Authorize]
    [HttpGet("getmyinfo")]
    public IActionResult GetMyInfo()
    {
      var username = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Name).Value;
      return Ok(_userService.GetUserInfoByUsername(username));
    }
    [HttpGet("sendpasswordresetcode")]
    public IActionResult SendPasswordReset(string username)
    {
      
      return Ok(_userService.SendPasswordResetCode(username));
    }
    [HttpPost("resetpassword")]
    public IActionResult ResetPassword(PasswordResetDto passwordResetDto)
    {
      return Ok(_userService.ResetPassword(passwordResetDto));
    }
    [HttpGet("resetcodecontrol")]
    public IActionResult ResetCodeControl(string code)
    {
      return Ok(_userService.PasswordResetCodeControl(code));
    }
    [HttpPost("updateprofile")]
    public IActionResult UpdateUser(EditProfileDto editProfileDto)
    {
      return Ok(_userService.UpdateUser(editProfileDto));

    }
    [Authorize]
    [HttpPost("changeprofilepicture")]
    public IActionResult ChangeProfilePicture([FromForm] IFormFile picture)
    {
      var wwwrootPath = _env.WebRootPath;
      var folder = wwwrootPath + "\\profile-pictures\\";
      if (!Directory.Exists(folder))
      {
        Directory.CreateDirectory(folder);
      }
      Guid guid = Guid.NewGuid();
      string extension = Path.GetExtension(picture.FileName);
      using (FileStream fileStream = System.IO.File.Create(folder + guid.ToString("N") + extension))
      {
        picture.CopyTo(fileStream);
        fileStream.Flush();
        return Ok(_userService.UpdateProfilePicture(guid.ToString("N")+extension));
      }
        
    }
  }
}
