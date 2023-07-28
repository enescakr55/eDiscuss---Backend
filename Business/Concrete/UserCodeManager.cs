using Business.Abstract;
using Core.Results.DataResults;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
  public class UserCodeManager : IUserCodeService
  {
    IUserCodeDal _userCodeDal;
    public UserCodeManager(IUserCodeDal userCodeDal)
    {
      _userCodeDal = userCodeDal;
    }

    public IDataResult<UserCode> Add(UserCode userCode)
    {
      var result = _userCodeDal.Add(userCode);
      return new SuccessDataResult<UserCode>(result);
    }

    public IDataResult<UserCode> Get(int userCodeId)
    {
      var result = _userCodeDal.Get(x=>x.UserCodeId == userCodeId);
      return new SuccessDataResult<UserCode>(result);
    }
  }
}
