using Core.DataAccess.Abstract;
using Core.Results.DataResults;
using Entities;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
  public interface IUserDal:ICrudBase<User>
  {
    public List<UserInfoDto> GetUserInfo(Expression<Func<UserInfoDto, bool>> filter = null);
  }
}
