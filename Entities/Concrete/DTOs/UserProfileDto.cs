using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
  public class UserProfileDto
  {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePhotoPath { get; set; }
        public int TotalDiscussions { get; set; }
        public int TotalReplies { get; set; }
        public List<DiscussDetailsDto> Discussions { get; set; }

    }
}
