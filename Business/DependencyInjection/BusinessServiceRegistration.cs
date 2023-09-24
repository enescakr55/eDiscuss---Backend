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
      services.AddScoped<IUserService, UserManager>();
      services.AddScoped<IAuthService, AuthManager>();
      services.AddScoped<IUserSubjectService, UserSubjectManager>();
      services.AddScoped<IDiscussService, DiscussManager>();
      services.AddScoped<ICategoryService, CategoryManager>();
      services.AddScoped<IReplyService, ReplyManager>();
      services.AddScoped<ISubjectService, SubjectManager>();
      services.AddScoped<IConversationService, ConversationManager>();
      services.AddScoped<IConversationUserService, ConversationUserManager>();
      services.AddScoped<INotificationService, NotificationManager>();
      services.AddScoped<ISavedCodeService, SavedCodeManager>();
      services.AddScoped<IUserCodeService, UserCodeManager>();
      services.AddScoped<IUserProfileManager, UserProfileManager>();
      return services;
    }
  }
}
