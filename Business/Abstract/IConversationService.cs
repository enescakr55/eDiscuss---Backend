using Core.Results;
using Core.Results.DataResults;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public interface IConversationService
  {
    IDataResult<Conversation> AddPersonalConversation(CreatePersonelConversationDto createPersonalConversation);
    IResult AddGroupConversation(Conversation conversation);
    IResult RemoveConversation(Conversation conversation);
    IResult LeaveConversation(Conversation conversation);
  }
}
