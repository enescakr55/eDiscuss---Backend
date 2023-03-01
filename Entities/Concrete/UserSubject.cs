using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
  public class UserSubject:IEntity
  {
    [Key]
    public int UserSubjectId { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public virtual User User { get; set; }

    [ForeignKey(nameof(Subject))]
    public int SubjectId { get; set; }
    public virtual Subject Subject { get; set; }
  }
}
