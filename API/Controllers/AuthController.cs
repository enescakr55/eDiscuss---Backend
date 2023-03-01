using Business.Abstract;
using Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    IAuthService _authService;
    public AuthController(IAuthService authService)
    {
      _authService = authService;
    }
    [HttpPost("register")]
    public IActionResult Register(RegisterDto registerDto)
    {

      return Ok(_authService.Register(registerDto));
    }
    [HttpPost("login")]
    public IActionResult Login(LoginDto loginDto)
    {
      return Ok(_authService.Login(loginDto));
    }
  }
}
