using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
  public class CategorySubjectDto
  {
    public Category category { get; set; }
    public List<Subject> subject { get; set; }
  }
}
