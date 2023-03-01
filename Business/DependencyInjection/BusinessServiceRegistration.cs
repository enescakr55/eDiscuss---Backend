using Business.Abstract;
using Business.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyInjection
{
  public static class BusinessServiceRegistration
  {
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
      services.AddSingleton<IUserService, UserManager>();
      services.AddSingleton<IAuthService, AuthManager>();
      services.AddSingleton<IUserSubjectService, UserSubjectManager>();
      services.AddSingleton<IDiscussService, DiscussManager>();
      services.AddSingleton<ICategoryService, CategoryManager>();
      services.AddSingleton<IReplyService, ReplyManager>();
      services.AddSingleton<ISubjectService, SubjectManager>();
      services.AddSingleton<IConversationService, ConversationManager>();
      services.AddSingleton<IConversationUserService, ConversationUserManager>();
      services.AddSingleton<INotificationService, NotificationManager>();
      return services;
    }
  }
}
