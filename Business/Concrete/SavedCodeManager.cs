using AutoMapper;
using Business.Abstract;
using Core.Results.DataResults;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using Entities.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
  public class SavedCodeManager : ISavedCodeService
  {
    IUserCodeService _userCodeService;
    IUserService _userService;
    ISavedCodeDal _savedCodeDal;
    IHttpContextHelperService _httpHelperService;
    IMapper _mapper;

    public SavedCodeManager(IUserService userService,IMapper mapper,IUserCodeService userCodeService,IHttpContextHelperService httpContextHelperService,ISavedCodeDal savedCodeDal)
    {
      _userCodeService = userCodeService;
      _httpHelperService = httpContextHelperService;
      _savedCodeDal = savedCodeDal;
      _mapper = mapper;
      _userService = userService;
    }
    public IDataResult<SavedCode> Add(AddSavedCodeDto savedCode)
    {
      var userCode = new UserCode();
      userCode.UserId = _httpHelperService.GetUserId();
      userCode.CodeType = savedCode.CodeType;
      userCode.CreatedDate = DateTime.UtcNow;
      var createdUserCode = _userCodeService.Add(userCode);
      SavedCode currentCode = new SavedCode();
      currentCode.AddedDate = DateTime.UtcNow;
      currentCode.CodeText = savedCode.CodeText;
      currentCode.CodeType = savedCode.CodeType;
      currentCode.UserCodeId = createdUserCode.Data.UserCodeId;
      var createdCode = _savedCodeDal.Add(currentCode);
      return new SuccessDataResult<SavedCode>(createdCode);
    }

    public IDataResult<ShowSavedCodeDto> GetCodeById(int savedCodeId)
    {
      var result = _savedCodeDal.Get(x=>x.SavedCodeId == savedCodeId);
      var userCodeResult = _userCodeService.Get(result.UserCodeId);
      var userResult = _userService.GetById(userCodeResult.Data.UserId);
      var userCodeMapped = _mapper.Map<UserCodeViewDto>(userCodeResult.Data);
      var userInfoMapped = _mapper.Map<UserInfoDto>(userResult.Data);
      var mappedResult = _mapper.Map<ShowSavedCodeDto>(result);
      mappedResult.UserInfo = userInfoMapped;
      mappedResult.UserCode = userCodeMapped;
      return new SuccessDataResult<ShowSavedCodeDto>(mappedResult);
    }
    public IDataResult<SavedCode> GetCodeTest(int savedCodeId){
      var result = _savedCodeDal.Get(x => x.SavedCodeId == savedCodeId);
      return new SuccessDataResult<SavedCode>(result);
    }

    public IDataResult<List<SavedCode>> GetCodesByCodeType(CodeTypes codeType)
    {
      throw new NotImplementedException();
    }

    public IDataResult<List<SavedCode>> GetCodesByUserCodeId(int userCodeId)
    {
      throw new NotImplementedException();
    }

    public IDataResult<SavedCode> Update(UpdateSavedCodeDto savedCodeDto)
    {
      var currentSavedCode = _savedCodeDal.Get(x => x.SavedCodeId == savedCodeDto.SavedCodeId);
      var currentUserCode = _userCodeService.Get(currentSavedCode.UserCodeId).Data;
      if(currentUserCode.UserId == _httpHelperService.GetUserId()){
        var savedCode = new SavedCode();
        savedCode.UserCodeId = currentUserCode.UserCodeId;
        savedCode.AddedDate = DateTime.UtcNow;
        savedCode.CodeType = currentSavedCode.CodeType;
        savedCode.CodeText = savedCodeDto.CodeText;
        var updated = _savedCodeDal.Add(savedCode);
        return new SuccessDataResult<SavedCode>(updated);
      }
      throw new Exception("An error occured");
      
    }
  }
}
