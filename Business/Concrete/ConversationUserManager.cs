using Business.Abstract;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
  public class ConversationUserManager : IConversationUserService
  {
    IConversationUserDal _conversationUserDal;

    public ConversationUserManager(IConversationUserDal conversationUserDal)
    {
      _conversationUserDal = conversationUserDal;
    }
    public IResult AddUserToConversation(int userId,int conversationId )
    {
      var conversationUser = new ConversationUser();
      conversationUser.UserId = userId;
      conversationUser.ConversationId = conversationId;
      conversationUser.DeletedTimestamp = null;
      _conversationUserDal.Add(conversationUser);
      return new SuccessResult();
    }
  }
}
