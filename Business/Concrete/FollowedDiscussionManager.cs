using Business.Abstract;
using Core.Results;
using Core.Results.DataResults;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
  public class FollowedDiscussionManager : IFollowedDiscussionService
  {
    IFollowedDiscussionDal _followedDiscussionDal;
    public FollowedDiscussionManager(IFollowedDiscussionDal followedDiscussionDal)
    {
      _followedDiscussionDal = followedDiscussionDal;
    }
    public IDataResult<FollowedDiscussion> Add(FollowedDiscussion followedDiscussion)
    {
      var addedEntity = _followedDiscussionDal.Add(followedDiscussion);
      return new SuccessDataResult<FollowedDiscussion>(addedEntity);
    }

    public IResult Delete(int followedDiscussionId)
    {
      var entity = _followedDiscussionDal.Get(x => x.FollowedDiscussionId == followedDiscussionId);
      _followedDiscussionDal.Delete(entity);
      return new SuccessResult();
    }

    public IDataResult<FollowedDiscussion> Get(int followedDiscussionId)
    {
      throw new NotImplementedException();
    }

    public IDataResult<List<FollowedDiscussion>> GetAll()
    {
      var followedDiscussions = _followedDiscussionDal.GetAll();
      return new SuccessDataResult<List<FollowedDiscussion>>(followedDiscussions);
    }

    public IResult Update(FollowedDiscussion followedDiscussion)
    {
      _followedDiscussionDal.Update(followedDiscussion);
      return new SuccessResult();
    }
  }
}
