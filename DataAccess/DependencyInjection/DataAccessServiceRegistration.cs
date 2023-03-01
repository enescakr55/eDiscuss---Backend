using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DependencyInjection
{
  public static class DataAccessServiceRegistration
  {
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
      services.AddSingleton<IUserDal, UserDal>();
      services.AddSingleton<ICategoryDal, CategoryDal>();
      services.AddSingleton<IReplyDal, ReplyDal>();
      services.AddSingleton<IDiscussDal, DiscussDal>();
      services.AddSingleton<ISubjectDal, SubjectDal>();
      services.AddSingleton<IUserSubjectDal, UserSubjectDal>();
      services.AddSingleton<IPasswordResetCodeDal, PasswordResetCodeDal>();
      services.AddSingleton<IConversationDal, ConversationDal>();
      services.AddSingleton<IMessageDal, MessageDal>();
      services.AddSingleton<IConversationUserDal, ConversationUserDal>();
      services.AddSingleton<INotificationDal, NotificationDal>();
      return services;
    }
  }
}
