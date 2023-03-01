using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
  public class ConversationAndUsers
  {
    public int ConversationId { get; set; }
    public bool GroupConversation { get; set; }
    public string? ConversationName { get; set; }
    public int? OwnerId { get; set; }
    public List<ConversationUser> ConversationUsers { get; set; }
  }
}
