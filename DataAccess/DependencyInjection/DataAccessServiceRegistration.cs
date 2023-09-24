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
      services.AddScoped<IUserDal, UserDal>();
      services.AddScoped<ICategoryDal, CategoryDal>();
      services.AddScoped<IReplyDal, ReplyDal>();
      services.AddScoped<IDiscussDal, DiscussDal>();
      services.AddScoped<ISubjectDal, SubjectDal>();
      services.AddScoped<IUserSubjectDal, UserSubjectDal>();
      services.AddScoped<IPasswordResetCodeDal, PasswordResetCodeDal>();
      services.AddScoped<IConversationDal, ConversationDal>();
      services.AddScoped<IMessageDal, MessageDal>();
      services.AddScoped<IConversationUserDal, ConversationUserDal>();
      services.AddScoped<INotificationDal, NotificationDal>();
      services.AddScoped<IUserCodeDal, UserCodeDal>();
      services.AddScoped<ISavedCodeDal, SavedCodeDal>();
      services.AddScoped<AppDbContext>();
      return services;
    }
  }
}
