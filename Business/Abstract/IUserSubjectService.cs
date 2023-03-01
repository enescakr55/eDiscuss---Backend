using Core.Results;
using Core.Results.DataResults;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public interface IUserSubjectService
  {
    IResult Add(UserSubject userSubject);
    IResult Delete(UserSubject userSubject);
    IDataResult<List<UserSubject>> GetAll();
    IDataResult<UserSubject> GetById(int id);
    IDataResult<List<UserSubject>> GetByUserId(int userId);
    IDataResult<UserSubject> GetByUserAndSubjectId(int userId, int subjectId);
    IDataResult<List<UserSubject>> GetUserSubjectsBySubjectId(int subjectId);
  }
}
