using Business.Abstract;
using Core.Results;
using Core.Results.DataResults;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.ConstantsFolder;
using Entities.Concrete.DTOs;
using Entities.Concrete;
using System.Net.Mail;
using Core.Helpers;
using DataAccess.Concrete;

namespace Business.Concrete
{
  public class UserManager : IUserService
  {
    IUserDal _userDal;
    IPasswordResetCodeDal _passwordResetCodeDal;
    IHttpContextHelperService _httpHelperService;
    AppDbContext _dbContext;
    public UserManager(IUserDal userDal, IPasswordResetCodeDal passwordResetCodeDal, IHttpContextHelperService httpHelperService,AppDbContext dbContext)
    {
      _userDal = userDal;
      _dbContext = dbContext;
      _passwordResetCodeDal = passwordResetCodeDal;
      _httpHelperService = httpHelperService;
    }
    public IResult AddUser(User user)
    {
      var getByEmail = _userDal.Get(x => x.Email.ToLower() == user.Email.ToLower());
      var getByUsername = _userDal.Get(x => x.Username.ToLower() == user.Username.ToLower());
      if (getByEmail != null)
      {
        return new ErrorResult(Constants.User_EmailExists);
      }
        
      if (getByUsername != null)
      {
        return new ErrorResult(Constants.User_UsernameExists);
      }
        
      _userDal.Add(user);
      return new SuccessResult(Constants.User_Added);
    }

    public IResult DeleteUser(int userId)
    {
      var user = _userDal.Get(x => x.Id == userId);
      _userDal.Delete(user);
      return new SuccessResult(Constants.User_Deleted) ;
    }

    public IDataResult<List<User>> GetAll()
    {
      return new SuccessDataResult<List<User>>(_userDal.GetAll());
    }

    public IDataResult<User> GetByEmail(string email)
    {
      return new SuccessDataResult<User>(_userDal.Get(x => x.Email == email));
    }

    public IDataResult<User> GetById(int id)
    {
      return new SuccessDataResult<User>(_userDal.Get(x => x.Id == id));
    }

    public IDataResult<User> GetByUsername(string username)
    {
      return new SuccessDataResult<User>(_userDal.Get(x => x.Username == username));
    }

    public IDataResult<UserInfoDto> GetUserInfoByUserId(int id)
    {
      return new SuccessDataResult<UserInfoDto>(_userDal.GetUserInfo(x => x.Id == id).FirstOrDefault());
    }

    public IDataResult<UserInfoDto> GetUserInfoByUsername(string username)
    {
      return new SuccessDataResult<UserInfoDto>(_userDal.GetUserInfo(x => x.Username == username).FirstOrDefault());
    }

    public IResult ResetPassword(PasswordResetDto passwordResetDto)
    {
      var resetCode = _passwordResetCodeDal.Get(x => x.ResetCode == passwordResetDto.ResetCode);
      if(resetCode != null)
      {
        var requestedUser = _userDal.Get(y => y.Id == resetCode.UserId);
        if(requestedUser != null)
        {
          string password = passwordResetDto.NewPassword;
          if(password.Length < 8)
          {
            return new ErrorResult("Parola 8 karakterden kısa olamaz");
          }
          byte[] passwordHash;
          byte[] passwordSalt;
          HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
          requestedUser.PasswordHash = passwordHash;
          requestedUser.PasswordSalt = passwordSalt;
          _userDal.Update(requestedUser);
          _passwordResetCodeDal.Delete(resetCode);
          return new SuccessResult();
        }
        
      }
      return new ErrorResult();
    }

    public IResult SendPasswordResetCode(string username)
    {
      var user = _userDal.Get(x => x.Username == username);
      PasswordResetCode resetCode = new PasswordResetCode();
      Random random = new Random();
      resetCode.ResetCode = Guid.NewGuid().ToString().Replace("-","") + random.Next()%10;
      resetCode.UserId = user.Id;
      resetCode.CreatedTime = DateTime.Now;
      var mail = "https://localhost:4200/password-reset/" + resetCode.ResetCode;
      _passwordResetCodeDal.Add(resetCode);
      SMTPManager smtpManager = new SMTPManager();
      var client = smtpManager.Client();
      try
      {
        MailMessage mm = new MailMessage(); // Hangi mail adresinden nereye, konu ve içerik mail ayarlarını yapabilirsiniz
        mm.From = new MailAddress("esnetce@yandex.com", "EDiscuss");
        mm.To.Add(user.Email);
        mm.IsBodyHtml = true; // True: Html olarak Gönderme, False: Text olarak Gönderme
        mm.Subject = "EDiscuss";
        mm.Body = mail;
        mm.BodyEncoding = UTF8Encoding.UTF8; // UTF8 encoding ayarı
        mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess; // Hata olduğunda uyarı ver 
        client.Send(mm);
      }
      catch(SmtpException e)
      {
        throw e;
      }
      return new SuccessResult();
    }
    public IResult PasswordResetCodeControl(string resetCode)
    {
      var prc = _passwordResetCodeDal.Get(x => x.ResetCode == resetCode);
      if(prc != null)
      {
        return new SuccessResult();
      }
      else
      {
        return new ErrorResult();
      }
    }

    public IResult UpdateUser(EditProfileDto user)
    {
      var username = _httpHelperService.GetUsername();
      var userinfo = _userDal.Get(x => x.Username == username);
      if(userinfo.Email.ToLower() != user.Email.ToLower())
      {
        var getByEmail = _userDal.Get(x=>x.Email.ToLower()==user.Email.ToLower());
        if (getByEmail != null)
          return new ErrorResult("E-Posta adresi mevcut");
        userinfo.Email = user.Email;
      }
      userinfo.FirstName = user.FirstName;
      userinfo.LastName = user.LastName;
      
      _userDal.Update(userinfo);
      return new SuccessResult(Constants.User_Updated);
    }

    public IResult UpdateProfilePicture(string photoPath)
    {
      var username = _httpHelperService.GetUsername();
      var currentUser = _userDal.Get(x => x.Username == username);
      currentUser.ProfilePhotoPath = photoPath;
      _userDal.Update(currentUser);
      return new SuccessResult("Profil fotoğrafı başarıyla güncellendi");
    }


  }
}
