using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
  public class PasswordResetCode:IEntity
  {
    public int Id { get; set; }

    [ForeignKey(nameof(User))]

    public int UserId { get; set; }
    public virtual User User { get; set; }
    public string ResetCode { get; set; }
    public DateTime CreatedTime { get; set; }
  }
}
