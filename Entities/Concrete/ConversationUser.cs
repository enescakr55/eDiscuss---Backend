using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
  public class ConversationUser:IEntity
  {
    public int ConversationUserId { get; set; }
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public virtual User User { get; set; }
    [ForeignKey(nameof(Conversation))]
    public int ConversationId { get; set; }
    public virtual Conversation Conversation { get; set; }
    public DateTime? DeletedTimestamp { get; set; }

  }
}
