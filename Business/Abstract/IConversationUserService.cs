using Business.Concrete;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public interface IConversationUserService
  {
    IResult AddUserToConversation(int userId, int conversationId);
  }
}
