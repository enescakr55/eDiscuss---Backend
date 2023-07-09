using Entities.Concrete;
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
    SavedCode Add(SavedCode savedCode);
    SavedCode Update(SavedCode savedCode);
    SavedCode GetCodeById(int savedCodeId);
    List<SavedCode> GetCodesByUserCodeId(int userCodeId);
    SavedCode GetCodesByCodeType(CodeTypes codeType);

  }
}
