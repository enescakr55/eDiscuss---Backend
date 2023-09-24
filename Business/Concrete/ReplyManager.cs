using Business.Abstract;
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
  
  public class ReplyManager : IReplyService
  {
    IReplyDal _replyDal;
    INotificationService _notificationService;
    public ReplyManager(IReplyDal replyDal, INotificationService notificationService)
    {
      _replyDal = replyDal;
      _notificationService = notificationService;
    }

    public IDataResult<Reply> Add(Reply entitity)
    {
      var reply = _replyDal.Add(entitity);
      _notificationService.SendReplyNotification(entitity);
      return new SuccessDataResult<Reply>(reply);
    }

    public IResult Delete(int replyid)
    {
      var reply = _replyDal.Get(x => x.ReplyId == replyid);
      _notificationService.DeleteReplyNotification(reply);
      _replyDal.Delete(_replyDal.Get(x=>x.ReplyId==replyid));
      return new SuccessResult();
    }

    public IDataResult<List<Reply>> GetAll()
    {
      return new SuccessDataResult<List<Reply>>(_replyDal.GetAll());
    }

    public IDataResult<Reply> GetById(int id)
    {
      return new SuccessDataResult<Reply>(_replyDal.Get(x => x.ReplyId == id));
    }

    public IDataResult<List<Reply>> GetRepliesByDiscussId(int discussId)
    {
      return new SuccessDataResult<List<Reply>>(_replyDal.GetAll(x => x.DiscussId == discussId));
    }

    public IDataResult<List<Reply>> GetRepliesByUserId(int id)
    {
      var result = _replyDal.GetAll(x => x.UserId == id);
      return new SuccessDataResult<List<Reply>>(result);
    }

    public IDataResult<List<RepliesDetailsDto>> GetReplyDetailsByDiscussId(int id)
    {
      var result = _replyDal.GetReplyDetails(x=>x.DiscussId == id);
      return new SuccessDataResult<List<RepliesDetailsDto>>(result);
    }
  }
}
