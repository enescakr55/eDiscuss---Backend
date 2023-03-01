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
  public class Subject:IEntity
  {
    [Key]
    public int SubjectId { get; set; }
    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }
    public string SubjectName { get; set; }
  //  public virtual Category Category { get; set; }
  }
}
