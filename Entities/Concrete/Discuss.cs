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
  public class Discuss:IEntity
  {
    [Key]
    public int DiscussId { get; set; }
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
   // public virtual User User { get; set; }
    [ForeignKey(nameof(Subject))]
    public int SubjectId { get; set; }
    //public virtual Subject Subject { get; set; }
    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }
    //public virtual Category Category { get; set; }
    public string DiscussHeader { get; set; }
    public string DiscussDescription { get; set; }
    public DateTime CreatedDate { get; set; }

    [ForeignKey(nameof(Reply))]
    public int Solution { get; set; } = default;
    public virtual Reply Reply { get; set; }
  }
}
