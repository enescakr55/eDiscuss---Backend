using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
  public class OnlineUser
  {
    [Key]
    public long OnlineUserId { get; set; }
    public int UserId { get; set; }
    public string Username { get; set; }
    public DateTime LastReport { get; set; }
    public bool IsOnline 
    {
      get { return LastReport.AddSeconds(40) > DateTime.UtcNow ? true : false; }
    }
  }
}
