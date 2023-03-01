using Entities.Abstract;
using Entities.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
  public class Notification:IEntity
  {
    public long NotificationId { get; set; }
    public int TriggeredUserId { get; set; } // 0 olursa sistem tarafından tetiklenen bir bildirim olur
    public int ReceiverId { get; set; }
    public string NotificationIcon { get; set; }
    public NotificationTypeEnum NotificationType { get; set; }
    [MaybeNull]
    public string NotificationValue { get; set; }
    [MaybeNull]
    public string ActionUrl { get; set; }
    public bool IsRead { get; set; }
    public DateTime SendDate { get; set; }
  }
}
