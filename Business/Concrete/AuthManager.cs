
using Business.Abstract;
using Core.Helpers;
using Core.Results;
using Core.Results.DataResults;
using Entities;
using Entities.Concrete.DTOs;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
  

  public class AuthManager : IAuthService
  {
    private readonly AppSettings _appSettings;
    IUserService _userService;
    public AuthManager(IOptions<AppSettings> appSettings,IUserService userService)
    {
      _appSettings = appSettings.Value;
      _userService = userService;
    }
    public IDataResult<ResponseTokenDto> Login(LoginDto loginDto)
    {
      //var user = TestDbValues.users.SingleOrDefault(x => x.Username == loginDto.Username && x.Password == loginDto.Password);
      var user = _userService.GetByUsername(loginDto.Username);
      if(user.Data == null)
      {
        return new ErrorDataResult<ResponseTokenDto>("Giriş Başarısız");
      }
      var isVerified = HashingHelper.VerifyPasswordHash(loginDto.Password, user.Data.PasswordHash, user.Data.PasswordSalt);
      if (!isVerified)
      {
        return new ErrorDataResult<ResponseTokenDto>("Giriş Başarısız");
      }
      var expiration = DateTime.UtcNow.AddHours(1);
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
          {
            new Claim(ClaimTypes.Name, user.Data.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Data.Id.ToString())
          }),
        Expires = expiration,
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      ResponseTokenDto responseToken = new ResponseTokenDto
      {
        Email = user.Data.Email,
        Expiration = expiration,
        Token = tokenHandler.WriteToken(token),
        Username = user.Data.Username,
      };
      return new SuccessDataResult<ResponseTokenDto>(responseToken);

    }

    public IResult Register(RegisterDto registerDto)
    {
      string password = registerDto.Password;
      byte[] passwordHash;
      byte[] passwordSalt;
      HashingHelper.CreatePasswordHash(password,out passwordHash, out passwordSalt);
      var user = new User
      {
        Username = registerDto.Username,
        FirstName = registerDto.FirstName,
        LastName = registerDto.LastName,
        PasswordSalt = passwordSalt,
        PasswordHash = passwordHash,
        Email = registerDto.Email
      };
      return _userService.AddUser(user);
    }
  }
}
