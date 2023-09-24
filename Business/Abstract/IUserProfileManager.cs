using Core.Results.DataResults;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public interface IUserProfileManager
  {
    IDataResult<UserProfileDto> GetUserProfile(string username);
  }
}
