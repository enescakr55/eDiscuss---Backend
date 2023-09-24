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
  public interface IReplyService
  {
    IDataResult<Reply> Add(Reply reply);

    IResult Delete(int replyid);
    IDataResult<List<Reply>> GetAll();
    IDataResult<List<Reply>> GetRepliesByDiscussId(int discussId);
    IDataResult<Reply> GetById(int id);
    IDataResult<List<RepliesDetailsDto>> GetReplyDetailsByDiscussId(int id);
    IDataResult<List<Reply>> GetRepliesByUserId(int id);
  }
}
