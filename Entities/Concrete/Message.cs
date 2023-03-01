using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
  public class Message : IEntity
  {
    public int MessageId { get; set; }
    [ForeignKey(nameof(User))]
    public int SenderId { get; set; }
    public virtual User User { get; set; }
    [ForeignKey(nameof(Conversation))]
    public int ConversationId { get; set; }
    public virtual Conversation Conversation { get; set; }
    public DateTime SendDate { get; set; }
    public string MessageType { get; set; }
    public string Text { get; set; }
    public string Link { get; set; }
  }
}
