using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
  public class DiscussDal : EFCrudBase<Discuss, AppDbContext>, IDiscussDal
  {
    public List<DiscussDetailsDto> GetDiscussDetails(Expression<Func<DiscussDetailsDto, bool>> filter = null)
    {
      using (AppDbContext dbContext = new AppDbContext())
      {
        var discussDetails = from d in dbContext.Discusses
                             join sub in dbContext.Subjects
                             on d.SubjectId equals sub.SubjectId
                             join user in dbContext.Users
                             on d.UserId equals user.Id
                             select new DiscussDetailsDto
                             {
                               SubjectName = sub.SubjectName,
                               CreatedDate = d.CreatedDate,
                               DiscussDescription = d.DiscussDescription,
                               DiscussHeader = d.DiscussHeader,
                               Username = user.Username,
                               DiscussId = d.DiscussId,
                               SubjectId = d.SubjectId,
                               CategoryId = d.CategoryId,
                               UserId = d.UserId
                             };
        return filter == null ? discussDetails.ToList() : discussDetails.Where(filter).ToList();
      }

    }
  }
}
