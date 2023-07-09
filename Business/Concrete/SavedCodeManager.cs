using Business.Abstract;
using Entities.Concrete;
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
    public SavedCode Add(SavedCode savedCode)
    {
      throw new NotImplementedException();
    }

    public SavedCode GetCodeById(int savedCodeId)
    {
      throw new NotImplementedException();
    }

    public SavedCode GetCodesByCodeType(CodeTypes codeType)
    {
      throw new NotImplementedException();
    }

    public List<SavedCode> GetCodesByUserCodeId(int userCodeId)
    {
      throw new NotImplementedException();
    }

    public SavedCode Update(SavedCode savedCode)
    {
      throw new NotImplementedException();
    }
  }
}
