using Business.Abstract;
using Core.Results.DataResults;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
  public class UserProfileManager : IUserProfileManager
  {
    IUserDal _userDal;
    IDiscussService _discussService;
    IReplyService _replyService;
    AppDbContext _dbContext;
    public UserProfileManager(IReplyService replyService, IDiscussService discussService, IUserDal userDal, IPasswordResetCodeDal passwordResetCodeDal, IHttpContextHelperService httpHelperService, AppDbContext dbContext)
    {
      _userDal = userDal;
      _replyService = replyService;
      _discussService = discussService;
      _dbContext = dbContext;
    }
    public IDataResult<UserProfileDto> GetUserProfile(string username)
    {
      
      var discussDetails = _discussService.GetDiscussDetailsByUsername(username);
      UserProfileDto userProfileDto = (from u in _dbContext.Users
                                       where u.Username == username
                                       from d in _dbContext.Discusses.Where(x=>x.UserId == u.Id).DefaultIfEmpty()
                                       select new UserProfileDto
                                       {
                                         Username = u.Username,
                                         UserId = u.Id,
                                         Discussions = discussDetails.Data ?? new List<DiscussDetailsDto>(),
                                         FirstName = u.FirstName,
                                         LastName = u.LastName,
                                         TotalDiscussions = discussDetails.Data != null ? discussDetails.Data.Count : 0,
                                         TotalReplies = _replyService.GetRepliesByUserId(u.Id).Data.Count,
                                         ProfilePhotoPath = u.ProfilePhotoPath ?? ""
                                       }).First();
      return new SuccessDataResult<UserProfileDto>(userProfileDto, "Kullanıcı profili getirildi");
    }
  }
}
