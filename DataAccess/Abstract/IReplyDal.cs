using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
  public interface IReplyDal : ICrudBase<Reply>
  {
    public List<RepliesDetailsDto> GetReplyDetails(Expression<Func<RepliesDetailsDto, bool>> filter = null);
  }
}
