using Core.Results.DataResults;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public interface IUserCodeService
  {
    public IDataResult<UserCode> Add(UserCode userCode);
    public IDataResult<UserCode> Get(int userCodeId);
  }
}
