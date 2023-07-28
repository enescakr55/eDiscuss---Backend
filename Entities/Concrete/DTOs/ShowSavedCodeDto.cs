using Entities.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
  public class ShowSavedCodeDto
  {
    public int SavedCodeId { get; set; }
    public int UserCodeId { get; set; }
    public UserCodeViewDto UserCode { get; set; }
    public UserInfoDto UserInfo { get; set; }

    public CodeTypes CodeType { get; set; }
    public string CodeText { get; set; }
    public DateTime AddedDate { get; set; }
  }
}
