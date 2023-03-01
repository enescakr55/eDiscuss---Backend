using AutoMapper;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
  public class ConversationProfile : Profile
  {
    public ConversationProfile()
    {
      CreateMap<Conversation, ConversationAndUsers>().ReverseMap();
    }

  }
}
