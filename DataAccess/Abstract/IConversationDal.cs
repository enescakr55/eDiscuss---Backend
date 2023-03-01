using Core.DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
  public interface IConversationDal:ICrudBase<Conversation>
  {
    public Conversation AddConversationWithResponse(Conversation conversation);
    public List<ConversationAndUsers> GetConversationAndUsers();
  }
}
