using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AssetsController : ControllerBase
  {
    IWebHostEnvironment _env;
    public AssetsController(IWebHostEnvironment env)
    {
      _env = env;
    }
    [HttpGet("GetCss")]
    public IActionResult GetCSS(string name = "default")
    {
      string reader = System.IO.File.ReadAllText(_env.WebRootPath+@"\styles\default.css");
      return Content(reader, "text/css");
    }
  }
}
