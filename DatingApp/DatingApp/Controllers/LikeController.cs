using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Api.Extensions;
using DatingApp.Api.Services.Interfaces;
using DatingApp.DataModel.Entities;
using DatingApp.ServiceModel.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILikeService _likeService;

        public LikeController(IUserService userService, ILikeService likeService)
        {
            _userService = userService;
            _likeService = likeService;
        }

        [HttpPost]

        public async Task<ActionResult> AddLike(int id)
        {
            var sourceUserId = User.GetUserId();
            var likedUser = await _userService.GetByIdAsync(id);
            var sourceUser = await _likeService.GetUserWithLikes(sourceUserId);
            if (likedUser == null) return NotFound();
            if (sourceUser.Id == id) return BadRequest("You cannot like userSelf");
            var userLike = await _likeService.GetUserLike(sourceUserId, likedUser.Id);
            if (userLike != null) return BadRequest("you already liked this user!!!");
            userLike = new UserLike
            {
                SourceUserId = sourceUserId,
                LikedUserId = likedUser.Id
            };
            sourceUser.LikedUsers.Add(userLike);
            if (await _userService.SaveAllChangesAsync()) return Ok();
            return BadRequest("Failed to like user!!!");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LikeDto>>> GetUserLikes(string predicate)
        {
            var users = await _likeService.GetUserLikes(predicate, User.GetUserId());
            return Ok(users);
        }

    }
}
