using Core.Results;
using Core.Results.DataResults;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public interface IAuthService
  {
    IDataResult<ResponseTokenDto> Login(LoginDto loginDto);
    IResult Register(RegisterDto registerDto);
  }
}
