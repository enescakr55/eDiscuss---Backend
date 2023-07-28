using Entities.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
  public class UpdateSavedCodeDto
  {
    public int SavedCodeId { get; set; }
    public CodeTypes CodeType { get; set; }
    public string CodeText { get; set; }
  }
}
