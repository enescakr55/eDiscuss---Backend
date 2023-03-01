using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
  public class RegisterDto:IDto
  {
    public string Username { get; set; }
    public string Email { get; set; }
    public string  FirstName { get; set; }
    public string  LastName { get; set; }
    public string  Password { get; set; }
  }
}
