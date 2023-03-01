using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
  public class ReplyDal : EFCrudBase<Reply, AppDbContext>, IReplyDal
  {
    public List<RepliesDetailsDto> GetReplyDetails(Expression<Func<RepliesDetailsDto, bool>> filter = null)
    {
      using(AppDbContext dbContext = new AppDbContext())
      {
        var result = from reply in dbContext.Replies
                     join user in dbContext.Users
                     on reply.UserId equals user.Id
                     select new RepliesDetailsDto
                     {
                       DiscussId = reply.DiscussId,
                       ReplyId = reply.ReplyId,
                       CreatedDate = reply.CreatedDate,
                       ReplyText = reply.ReplyText,
                       Username = user.Username
                     };
        return filter == null ? result.ToList() : result.Where(filter).ToList();
      }
    }
  }
}
