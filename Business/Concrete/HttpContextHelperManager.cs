using Business.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
  public class HttpContextHelperManager:IHttpContextHelperService
  {
    IHttpContextAccessor _httpContextAccessor;
    public HttpContextHelperManager(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }
    public string GetUsername()
    {
      string userName = _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Name).Value;
      return userName;
    }
    public int GetUserId()
    {
      string userIdStr = _httpContextAccessor.HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
      int userId = int.Parse(userIdStr);
      return userId;
    }
  }
}
