using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
  public class UserCodeContent
  {
        public UserCodeViewDto UserCodeView { get; set; }
        public List<ShowSavedCodeDto> SavedCodes { get; set; }
    }
}
