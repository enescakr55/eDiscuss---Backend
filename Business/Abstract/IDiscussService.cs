using Core.Results;
using Core.Results.DataResults;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public interface IDiscussService
  {
    IDataResult<Discuss> Add(Discuss discuss);
    IResult Delete(int discussid);
    IDataResult<List<Discuss>> GetAll();
    IDataResult<Discuss> GetById(int id);
    IDataResult<List<Discuss>> GetBySubjectId(int subjectId, int page = 0, int pageSize = 10);
    IDataResult<List<DiscussDetailsDto>> GetDiscussDetails(int page=0, int pageSize = 10);
    IDataResult<DiscussDetailsDto> GetDiscussDetailsByDiscussId(int discussId);
    IDataResult<List<DiscussDetailsDto>> GetDiscussDetailsBySubjectId(int subjectId,int page=0,int pageSize=10);
    IDataResult<List<DiscussDetailsDto>> GetDiscussDetailsByUserId(int userId);
    IDataResult<List<DiscussDetailsDto>> GetMyInterestingDiscuss(int userId, int page = 0, int pageSize = 10);
    IDataResult<List<DiscussDetailsDto>> GetFilteredDiscuss(DiscussFilterDto filterDto, int userId = -1, int page = 0, int pageSize = 10);
    IDataResult<List<DiscussDetailsDto>> GetDiscussDetailsByUsername(string userName);
  }
}
