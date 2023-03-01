using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
  public class Conversation:IEntity
  {
    public int ConversationId { get; set; }
    public bool GroupConversation { get; set; }
    public string? ConversationName { get; set; }
    public int? OwnerId { get; set; }
  }
}
