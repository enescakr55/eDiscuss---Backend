using Entities.Abstract;
using Entities.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
  public class SavedCode :IEntity
  {
    [Key]
    public int SavedCodeId { get; set; }
    [ForeignKey(nameof(UserCode))]
    public int UserCodeId { get; set; }
    public virtual UserCode UserCode { get; set; }
    public CodeTypes CodeType { get; set; }
    public string CodeText { get; set; }
    public DateTime AddedDate { get; set; }
  }
}
