using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
  public class DiscussFilterDto
  {
    public int[]? Subjects { get; set; }
    public string? DiscussTitle { get; set; }
    public bool? OnlyFavorites { get; set; }
  }
}
