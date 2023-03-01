using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
  public class UserSubjectDal : EFCrudBase<UserSubject, AppDbContext>, IUserSubjectDal
  {
  }
}
