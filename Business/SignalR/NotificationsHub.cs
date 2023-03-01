using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.SignalR
{
  public class NotificationsHub:Hub
  {
    public override Task OnConnectedAsync()
    {
      //var obj = new { message="message",title="title"};
      //Clients.Caller.SendAsync("PopNotifications", obj);
      return base.OnConnectedAsync();
    }
  }
}
