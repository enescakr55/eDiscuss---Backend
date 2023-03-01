using AutoMapper;
using Business.Abstract;
using Core.Results;
using Core.Results.DataResults;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
  public class ConversationManager : IConversationService
  {
    IConversationDal _conversationDal;
    IUserService _userService;
    IConversationUserService _conversationUserService;
    IMapper _mapper;
    IHttpContextHelperService _httpContextHelperService;
    public ConversationManager(IConversationDal conversationDal,IMapper mapper, IUserService userService, IConversationUserService conversationUserService,IHttpContextHelperService httpContextHelperService)
    {
      _conversationDal = conversationDal;
      _httpContextHelperService = httpContextHelperService;
      _userService = userService;
      _conversationUserService = conversationUserService;
      _mapper = mapper;
    }
    public IResult AddGroupConversation(Conversation conversation)
    {
      throw new NotImplementedException();
    }

    public IDataResult<Conversation> AddPersonalConversation(CreatePersonelConversationDto createPersonalConversation)
    {
      //Conversation conversation = _mapper.Map<Conversation>(createPersonalConversation);
      Conversation conversation = new Conversation();
      conversation.GroupConversation = false;
      Guid guid = Guid.NewGuid();
      conversation.ConversationName = guid.ToString("N");
      var user = _userService.GetById(_httpContextHelperService.GetUserId());
      var requestedUser = _userService.GetById(createPersonalConversation.UserId);
      if(user.Data.Id == requestedUser.Data.Id)
      {
        return new ErrorDataResult<Conversation>();
      }
      if(user.Data != null && requestedUser.Data != null)
      {
        var currentConversationUsers = PrivateConversationControl(createPersonalConversation.UserId, _httpContextHelperService.GetUserId());
        if (currentConversationUsers != null)
        {
          Conversation oldConversation = _mapper.Map<Conversation>(currentConversationUsers);
          return new SuccessDataResult<Conversation>(oldConversation);
        }
        var addedConversation = _conversationDal.AddConversationWithResponse(conversation);
        _conversationUserService.AddUserToConversation(user.Data.Id, addedConversation.ConversationId);
        _conversationUserService.AddUserToConversation(requestedUser.Data.Id, addedConversation.ConversationId);
        var newConversationUsers = PrivateConversationControl(createPersonalConversation.UserId, _httpContextHelperService.GetUserId());
        Conversation newConversation = _mapper.Map<Conversation>(newConversationUsers);
        return new SuccessDataResult<Conversation>(newConversation);
      }
      return new ErrorDataResult<Conversation>();
    }
    private ConversationAndUsers PrivateConversationControl(int user1,int user2)
    {
      var conversations = _conversationDal.GetConversationAndUsers();
      var filter = conversations.Where(x => x.GroupConversation == false && (x.ConversationUsers.Any(y=>y.UserId == user1) && x.ConversationUsers.Any(y=>y.UserId == user2))).ToList();
      if(filter.Count > 0)
      {
        return filter.FirstOrDefault();
      }
      return null;
    }

    public IResult LeaveConversation(Conversation conversation)
    {
      throw new NotImplementedException();
    }

    public IResult RemoveConversation(Conversation conversation)
    {
      throw new NotImplementedException();
    }
  }
}
