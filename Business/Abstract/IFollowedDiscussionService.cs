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
  public interface IFollowedDiscussionService
  {
    public IDataResult<FollowedDiscussion> Add(FollowedDiscussion followedDiscussion);
    public IResult Update(FollowedDiscussion followedDiscussion);
    public IResult Delete(int followedDiscussionId);
    public IDataResult<List<FollowedDiscussion>> GetAll();
    public IDataResult<FollowedDiscussion> Get(int followedDiscussionId);




  }
}
