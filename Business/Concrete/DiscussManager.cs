using Business.Abstract;
using Business.Config;
using Core.Results;
using Core.Results.DataResults;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
  public class DiscussManager : IDiscussService
  {
    IDiscussDal _discussDal;
    ISubjectService _subjectService;
    public DiscussManager(IDiscussDal discussDal, ISubjectService subjectService)
    {
      _discussDal = discussDal;
      _subjectService = subjectService;

    }
    public IDataResult<Discuss> Add(Discuss discuss)
    {
      var addedDiscuss = _discussDal.Add(discuss);
      //_notificationService.SendNewDiscussionNotification(addedDiscuss);
      return new SuccessDataResult<Discuss>(addedDiscuss);
    }

    public IResult Delete(int discussid)
    {

      _discussDal.Delete(_discussDal.Get(x=>x.DiscussId == discussid));
      return new SuccessResult();
    }

    public IDataResult<List<Discuss>> GetAll()
    {
      return new SuccessDataResult<List<Discuss>>(_discussDal.GetAll());
    }

    public IDataResult<Discuss> GetById(int id)
    {
      return new SuccessDataResult<Discuss>(_discussDal.Get(x=>x.DiscussId == id));
    }

    public IDataResult<List<Discuss>> GetBySubjectId(int subjectId, int page = 0,int pageSize=10)
    {
      return new SuccessDataResult<List<Discuss>>(_discussDal.GetAll(x => x.SubjectId == subjectId).OrderByDescending(x => x.CreatedDate).Skip(page*pageSize).Take(pageSize).ToList());
    }
    public IDataResult<List<DiscussDetailsDto>> GetDiscussDetails(int page = 0,int pageSize=10)
    {
      return new SuccessDataResult<List<DiscussDetailsDto>>(_discussDal.GetDiscussDetails().OrderByDescending(x=>x.CreatedDate).Skip(page*pageSize).Take(pageSize).ToList());
    }

    public IDataResult<DiscussDetailsDto> GetDiscussDetailsByDiscussId(int discussId)
    {
      return new SuccessDataResult<DiscussDetailsDto>(_discussDal.GetDiscussDetails(x => x.DiscussId == discussId).FirstOrDefault());
    }

    public IDataResult<List<DiscussDetailsDto>> GetDiscussDetailsBySubjectId(int subjectId, int page = 0,int pageSize=10)
    {
      return new SuccessDataResult<List<DiscussDetailsDto>>(_discussDal.GetDiscussDetails(x => x.SubjectId == subjectId).OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize).ToList());
    }
    public IDataResult<List<DiscussDetailsDto>> GetDiscussDetailsByUserId(int userId)
    {
      return new SuccessDataResult<List<DiscussDetailsDto>>(_discussDal.GetDiscussDetails(x => x.UserId == userId).OrderByDescending(x => x.CreatedDate).ToList());
    }
    public IDataResult<List<DiscussDetailsDto>> GetDiscussDetailsByUsername(string userName)
    {
      return new SuccessDataResult<List<DiscussDetailsDto>>(_discussDal.GetDiscussDetails(x => x.Username == userName));
    }
    public IDataResult<List<DiscussDetailsDto>> GetFilteredDiscuss(DiscussFilterDto filterDto, int userId = -1, int page = 0,int pageSize=10)
    {
      List<DiscussDetailsDto> discussions = new List<DiscussDetailsDto>();
      var title = filterDto.DiscussTitle != null ? filterDto.DiscussTitle : "";
      bool onlyFav = filterDto.OnlyFavorites != null && filterDto.OnlyFavorites != false ? true : false;
      if (onlyFav)
      {
        discussions = GetMyInterestingDiscuss(userId).Data.Where(x => x.DiscussHeader.ToLower().Contains(title.ToLower())).Skip(page*pageSize).Take(pageSize).ToList();
      }
      else
      {
        discussions = _discussDal.GetDiscussDetails(x => x.DiscussHeader.Contains(title)).Skip(page*pageSize).Take(pageSize).ToList();
      }
      
      return new SuccessDataResult<List<DiscussDetailsDto>>(discussions);
    }

    public IDataResult<List<DiscussDetailsDto>> GetMyInterestingDiscuss(int userId, int page = 0, int pageSize = 10)
    {
      var myCategorySubjects = _subjectService.GetMyCategorySubjects(userId);
      List<int> subjectIds = new List<int>();
      foreach (var categorySubject in myCategorySubjects.Data)
      {
        categorySubject.subject.ForEach(x => subjectIds.Add(x.SubjectId));
      }
      var discussions = _discussDal.GetDiscussDetails(x => subjectIds.Contains(x.SubjectId)).OrderByDescending(x => x.CreatedDate).ToList();
      return new SuccessDataResult<List<DiscussDetailsDto>>(discussions);
    }
  }
}
