using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
  public class DiscussDetailsDto
  {
    public int DiscussId { get; set; }
    public string DiscussHeader { get; set; }
    public string DiscussDescription { get; set; }
    public string SubjectName { get; set; }
    public int SubjectId { get; set; }
    public int CategoryId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Username { get; set; }
    public int UserId { get; set; }
  }
}
