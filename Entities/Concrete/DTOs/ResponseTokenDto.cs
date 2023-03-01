using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
  public class ResponseTokenDto
  {
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
  }
}
