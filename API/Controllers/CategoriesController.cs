using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoriesController : ControllerBase
  {
    ICategoryService _categoryService;
    public CategoriesController(ICategoryService categoryService)
    {
      _categoryService = categoryService;
    }
    [HttpGet("getcategories")]
    public IActionResult GetCategories()
    {
      return Ok(_categoryService.GetAll());
    }
    [Authorize(Roles ="admin")]
    [HttpPost("addcategory")]
    public IActionResult AddCategory(Category category)
    {
      return Ok(_categoryService.Add(category));
    }
    [Authorize(Roles = "admin")]
    [HttpPost("deletecategory")]
    public IActionResult DeleteCategory(Category category)
    {
      return Ok(_categoryService.Delete(category));
    }
    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
      return Ok(_categoryService.GetById(id));
    }
  }
}
