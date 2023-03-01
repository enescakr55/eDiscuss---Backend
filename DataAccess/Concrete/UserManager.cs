using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
  public class UserDal : EFCrudBase<User, AppDbContext>, IUserDal
  {
    public List<UserInfoDto> GetUserInfo(Expression<Func<UserInfoDto, bool>> filter = null)
    {
      using(AppDbContext db = new AppDbContext())
      {
        var result = from user in db.Users
                     select new UserInfoDto
                     {
                       Email = user.Email,
                       FirstName = user.FirstName,
                       LastName = user.LastName,
                       Username = user.Username,
                       Id = user.Id,
                       ProfilePhotoPath = user.ProfilePhotoPath
                     };
        return filter == null ? result.ToList() : result.Where(filter).ToList();
      }
    }
  }
}
