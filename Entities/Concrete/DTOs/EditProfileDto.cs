using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
  public class EditProfileDto
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
  }
}
