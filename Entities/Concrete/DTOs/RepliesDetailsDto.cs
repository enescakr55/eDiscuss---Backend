using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
  public class RepliesDetailsDto
  {
    public int ReplyId { get; set; }
    public int DiscussId { get; set; }
    public string Username { get; set; }
    public string ReplyText { get; set; }
    public DateTime CreatedDate { get; set; }
  }
}
