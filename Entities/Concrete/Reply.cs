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
  public class Reply:IEntity
  {
    [Key]
    public int ReplyId { get; set; }
    [ForeignKey(nameof(Discuss))]
    public int DiscussId { get; set; }
    //public virtual Discuss Discuss { get; set; }
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public string ReplyText { get; set; }
    public DateTime CreatedDate { get; set; }
  }
}
