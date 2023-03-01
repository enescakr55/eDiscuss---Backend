using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
  public class SendNotificationDto
  {
    public string Title { get; set; }
    public string Message { get; set; }
    public string ActionLink { get; set; } = null;
  }
}
