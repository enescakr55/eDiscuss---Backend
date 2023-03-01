using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
  public static class GuidGenerator
  {
    public static string GetGuid()
    {
      return Guid.NewGuid().ToString();
    }
  }
}
