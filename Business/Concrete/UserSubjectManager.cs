using Business.Abstract;
using Core.Results;
using Core.Results.DataResults;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
  public class UserSubjectManager:IUserSubjectService
  {
    IUserSubjectDal _userSubjectDal;
    public UserSubjectManager(IUserSubjectDal userSubjectDal)
    {
      _userSubjectDal = userSubjectDal;
    }
    public IResult Add(UserSubject userSubject)
    {
      var data = _userSubjectDal.Get(x=>x.UserId == userSubject.UserId && x.SubjectId == userSubject.SubjectId);
      if(data == null)
      {
        _userSubjectDal.Add(userSubject);
        return new SuccessResult();
      }
      return new ErrorResult("Bu konu daha önce eklenmiş");
      
    }

    public IResult Delete(UserSubject userSubject)
    {
      _userSubjectDal.Delete(userSubject);
      return new SuccessResult();
    }

    public IDataResult<List<UserSubject>> GetAll()
    {
      return new SuccessDataResult<List<UserSubject>>(_userSubjectDal.GetAll());
    }

    public IDataResult<UserSubject> GetById(int id)
    {
      return new SuccessDataResult<UserSubject>(_userSubjectDal.Get(x => x.UserSubjectId == id));
    }

    public IDataResult<UserSubject> GetByUserAndSubjectId(int userId, int subjectId)
    {
      var subject = _userSubjectDal.Get(x=>x.UserId == userId && x.SubjectId == subjectId);
      return new SuccessDataResult<UserSubject>(subject);
    }

    public IDataResult<List<UserSubject>> GetByUserId(int userId)
    {
     var userSubjects = _userSubjectDal.GetAll(x => x.UserId == userId);
      return new SuccessDataResult<List<UserSubject>>(userSubjects);

    }

    public IDataResult<List<UserSubject>> GetUserSubjectsBySubjectId(int subjectId)
    {
      var userSubjects = _userSubjectDal.GetAll(x => x.SubjectId == subjectId);
      return new SuccessDataResult<List<UserSubject>>(userSubjects);
    }
  }
}
