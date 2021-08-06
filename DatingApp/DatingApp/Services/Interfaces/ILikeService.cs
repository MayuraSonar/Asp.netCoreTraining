using DatingApp.DataModel.Entities;
using DatingApp.ServiceModel.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Api.Services.Interfaces
{
    public interface ILikeService
    {
        Task<UserLike> GetUserLike(int sourceId, int likedUserId);
        Task<User> GetUserWithLikes(int userId);
        Task<IEnumerable<LikeDto>> GetUserLikes(string predicate, int userId);
    }
}
