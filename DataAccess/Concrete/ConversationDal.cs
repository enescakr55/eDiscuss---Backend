using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
  public class ConversationDal : EFCrudBase<Conversation, AppDbContext>, IConversationDal
  {
    public Conversation AddConversationWithResponse(Conversation conversation)
    {
      using (AppDbContext context = new AppDbContext())
      { 
        var addedEntity = context.Add<Conversation>(conversation);
        context.SaveChanges();
        return addedEntity.Entity;
      }
    }

    public List<ConversationAndUsers> GetConversationAndUsers()
    {
      using (AppDbContext context = new AppDbContext())
      {
        var result = from c in context.Conversations
                     select new ConversationAndUsers
                     {
                       ConversationId = c.ConversationId,
                       ConversationName = c.ConversationName,
                       GroupConversation = c.GroupConversation,
                       OwnerId = c.OwnerId,
                       ConversationUsers = context.ConversationUsers.Where(x => x.ConversationId == c.ConversationId).ToList()
                     };
        return result.ToList();
      }
    }
  }
}
