using Core.Results;
using Core.Results.DataResults;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public interface IUserService
  {
    IResult AddUser(User user);
    IResult UpdateUser(EditProfileDto user);
    IResult SendPasswordResetCode(string username);
    IResult PasswordResetCodeControl(string resetCode);
    IResult ResetPassword(PasswordResetDto passwordResetDto);
    IResult DeleteUser(int userId);
    IDataResult<User> GetByUsername(string username);
    IDataResult<User> GetByEmail(string email);
    IDataResult<User> GetById(int id);
    IDataResult<List<User>> GetAll();
    IDataResult<UserInfoDto> GetUserInfoByUserId(int id);
    IDataResult<UserInfoDto> GetUserInfoByUsername(string username);
    IResult UpdateProfilePicture(string photoPath);
  }
}
