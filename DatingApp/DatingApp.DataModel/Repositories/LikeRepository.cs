using DatingApp.DataModel.Context;
using DatingApp.DataModel.Entities;
using DatingApp.DataModel.Repositories.Interfaces;
using DatingApp.ServiceModel.DTOs.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.DataModel.Repositories
{
   public class LikeRepository :ILikeRepository
    {
        private readonly DatingAppDbContext _datingAppDbContext;

        public LikeRepository(DatingAppDbContext datingAppDbContext)
        {
            _datingAppDbContext = datingAppDbContext;
        }

        public async Task<UserLike> GetUserLike(int sourceId, int likedUserId)
        {
            return await _datingAppDbContext.Like.FindAsync(sourceId, likedUserId);
        }

        public async Task<IEnumerable<LikeDto>> GetUserLikes(string predicate, int userId)
        {
            var users = _datingAppDbContext.User.OrderBy(u => u.Id).AsQueryable();
            var likes = _datingAppDbContext.Like.AsQueryable();

            if(predicate=="liked")
            {
                likes = likes.Where(like => like.SourceUserId == userId);
                users =likes.Select(like => like.LikedUser);
            }
            if (predicate == "likedBy")
            {
                likes = likes.Where(like => like.LikedUserId == userId);
                users = likes.Select(like => like.SourceUser);
            }

            return await users.Select(user => new LikeDto
            {
                Name = user.Name,
                KnownAs = user.KnowAs,
                Country = user.Country,
                PhotoUrl = user.Photos.FirstOrDefault(p => p.IsMain).Url,
                Id = user.Id
            }).ToListAsync();
        }

        public async Task<User> GetUserWithLikes(int userId)
        {
            return await _datingAppDbContext.User.Include(x => x.LikedUsers).FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
