using Core.DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
  public interface IDiscussDal : ICrudBase<Discuss>
  {
    List<DiscussDetailsDto> GetDiscussDetails(Expression<Func<DiscussDetailsDto, bool>> filter = null);
  }
}
