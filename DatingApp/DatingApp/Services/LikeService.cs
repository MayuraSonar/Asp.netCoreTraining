using DatingApp.Api.Services.Interfaces;
using DatingApp.DataModel.Entities;
using DatingApp.DataModel.Repositories.Interfaces;
using DatingApp.ServiceModel.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Api.Services
{
    public class LikeService:ILikeService
    {
        private readonly ILikeRepository _likeRepository;

        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<UserLike> GetUserLike(int sourceId, int likedUserId)
        {
           return await _likeRepository.GetUserLike(sourceId, likedUserId);
        }

        public async Task<IEnumerable<LikeDto>> GetUserLikes(string predicate, int userId)
        {
            return await _likeRepository.GetUserLikes(predicate, userId);
        }

        public async Task<User> GetUserWithLikes(int userId)
        {
            return await _likeRepository.GetUserWithLikes(userId);
        }
    }
}
