using DatingApp.DataModel.Entities;
using DatingApp.ServiceModel.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.DataModel.Repositories.Interfaces
{
    public interface  ILikeRepository
    {
        Task<UserLike> GetUserLike(int sourceId, int likedUserId);
        Task<User> GetUserWithLikes(int userId);
        Task<IEnumerable<LikeDto>> GetUserLikes(string predicate, int userId);
    }
}
