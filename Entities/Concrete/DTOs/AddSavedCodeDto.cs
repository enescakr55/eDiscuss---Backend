using Entities.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
  public class AddSavedCodeDto
  {
    public CodeTypes CodeType { get; set; }
    public string CodeText { get; set; }
  }
}
