using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ConversationsController : ControllerBase
  {
    IHttpContextHelperService _httpContextHelperService;
    IConversationService _conversationService;
    public ConversationsController(IHttpContextHelperService httpContextHelperService, IConversationService conversationService)
    {
      _httpContextHelperService = httpContextHelperService;
      _conversationService = conversationService;
    }
    [HttpGet("getUserId")]
    public IActionResult GetUserId()
    {
      return Ok(_httpContextHelperService.GetUserId());
    }
    [HttpGet("getUsername")]
    public IActionResult GetUsername()
    {
      return Ok(_httpContextHelperService.GetUsername());
    }
    [HttpPost("AddPersonalConversation")]
    public IActionResult AddPersonalConversation(CreatePersonelConversationDto createPersonelConversation)
    {
      return Ok(_conversationService.AddPersonalConversation(createPersonelConversation));
    }

  }
}
