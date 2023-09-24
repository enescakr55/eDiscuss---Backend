using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Pagination
{
  public interface IPageInfo<T>
  {
        public int PageItemCount { get; }
        public int TotalPage { get; }
        public int Page { get; }
        public List<T> Data { get; }
    }
}
