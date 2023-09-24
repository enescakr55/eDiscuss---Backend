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
  public class UserCodeDal : EFCrudBase<UserCode,AppDbContext>, IUserCodeDal
  {
    /*public UserCodeContent GetUserCodeContent(){
      using(var context = new AppDbContext()){
        return from userCode in context.UserCodes
               join savedCodes in context.SavedCodes
               select new UserCodeContent {
               SavedCodes 
               }
      }
    }*/
  }
}
