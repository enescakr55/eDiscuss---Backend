using Core.Results.DataResults;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using Entities.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public interface ISavedCodeService
  {
    IDataResult<SavedCode> Add(AddSavedCodeDto savedCode);
    IDataResult<SavedCode> Update(UpdateSavedCodeDto savedCodeDto);
    IDataResult<ShowSavedCodeDto> GetCodeById(int savedCodeId);
    IDataResult<List<SavedCode>> GetCodesByUserCodeId(int userCodeId);
    IDataResult<List<SavedCode>> GetCodesByCodeType(CodeTypes codeType);
    IDataResult<SavedCode> GetCodeTest(int savedCodeId);

  }
}
