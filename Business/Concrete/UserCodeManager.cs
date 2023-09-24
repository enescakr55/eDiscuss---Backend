using Business.Abstract;
using Core.Results.DataResults;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Concrete.DTOs;
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
    AppDbContext _appDbContext;

    public UserCodeManager(IUserCodeDal userCodeDal, AppDbContext appDbContext)
    {
      _userCodeDal = userCodeDal;
      _appDbContext = appDbContext;
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
    public IDataResult<List<UserCode>> GetAllByUserId(int userId) {
      var result = _userCodeDal.GetAll(x=>x.UserId == userId);
      return new SuccessDataResult<List<UserCode>>(result, "Veri alındı");
    }
    public IDataResult<UserCodeContent> GetUserCodeDetailsByUserCodeId(int userCodeId){
      var userCode = _appDbContext.UserCodes.FirstOrDefault(x => x.UserCodeId == userCodeId);
      UserCodeViewDto userCodeView = new UserCodeViewDto();
      userCodeView.UserId = userCode.UserId;
      userCodeView.UserCodeId = userCode.UserCodeId;
      userCodeView.UpdatedDate = userCode.UpdatedDate;
      userCodeView.CreatedDate = userCode.CreatedDate;
      userCodeView.CodeType = userCode.CodeType;
      userCodeView.Description = userCode.Description;
      
      var result = from c in userCode.SavedCodes
                   select new ShowSavedCodeDto
                   {
                     AddedDate = c.AddedDate,
                     CodeText = c.CodeText,
                     CodeType = c.CodeType,
                     SavedCodeId = c.SavedCodeId,
                     UserCodeId = c.UserCodeId
                   };
      var savedCodeList = result.ToList();
      
      var userCodeContent = new UserCodeContent();
      userCodeContent.UserCodeView = userCodeView;
      userCodeContent.SavedCodes = savedCodeList;
      return new SuccessDataResult<UserCodeContent>(userCodeContent);
    }
  }
}
