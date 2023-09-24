using Core.DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Pagination
{
  public class PageInfo<T> : IPageInfo<T> where T : class,IEntity,new()
  {
    public PageInfo(int pageItemCount, int totalPage, int page, List<T> data)
    {
      PageItemCount = pageItemCount;
      TotalPage = totalPage;
      Page = page;
      Data = data;
    }
    public int PageItemCount { get; }
    public int TotalPage { get; }
    public int Page { get; }
    public List<T> Data { get; }
  }

}
