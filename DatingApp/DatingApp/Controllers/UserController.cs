using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.Api.Extensions;
using DatingApp.Api.Services.Interfaces;
using DatingApp.DataModel.Entities;
using DatingApp.ServiceModel.DTOs.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;

        public UserController(IUserService userService, IMapper mapper, IPhotoService photoService)
        {
            _userService = userService;
            _mapper = mapper;
            _photoService = photoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUserAsync()
        {
            //return await _userService.GetAllAsync();

            var user = await _userService.GetAllAsync();
            var response = _mapper.Map<IEnumerable<UserDto>>(user);
            return Ok(response);
        }


        [HttpGet("{id}", Name = "GetUser")]
        [Authorize]
        public async Task<ActionResult<UserDto>> GetUserByIdAsync(int Id)
        {
            var user = await _userService.GetByIdAsync(Id);
            var response = _mapper.Map<UserDto>(user);

            return response;
        }

        [HttpPut("edit")]
        public async Task<ActionResult> UpdateUser(UserUpdateDto userUpdateDto)
        {
            var userId = await _userService.GetByIdAsync(User.GetUserId());
            //var user = await _userService.GetByIdAsync(id);
            var result = _mapper.Map(userUpdateDto, userId);
            _userService.Update(result);

            if (await _userService.SaveAllChangesAsync())
                return NoContent();

            return BadRequest("Updation Failed!!");
        }

        [HttpPost("add-photos")]
        public async Task<ActionResult<PhotoDto>> AddPhotoAsync(IFormFile formFile)
        {
            var user = await _userService.GetByIdAsync(User.GetUserId());
            var response = await _photoService.AddPhotoAsync(formFile);
            if(response.Error!=null)
            {
                return BadRequest(response.Error.Message);
            }

            var photo = new Photo
            {
                Url = response.SecureUrl.AbsoluteUri,
                PublicId = response.PublicId
            };

            if(user.Photos.Count==0)
            {
                photo.IsMain = true;
            }

            user.Photos.Add(photo);

            if( await _userService.SaveAllChangesAsync())
            {
                // return _mapper.Map<PhotoDto>(photo);
                return CreatedAtRoute("GetUser", new { id = user.Id }, _mapper.Map<PhotoDto>(photo));
            }

            return BadRequest("Uploading Failed!!!");
        }

        [HttpDelete("delete-photos/{id}")]
        public async Task<ActionResult> DeletePhoto(int id)
        {
            var userId= await _userService.GetByIdAsync(User.GetUserId());
            var photoId = userId.Photos.FirstOrDefault(p => p.Id == id);
            if (photoId == null) return NotFound();
            if (photoId.IsMain) return BadRequest("You cannot delete the Main Photo");
            if(photoId.PublicId!=null)
            {
                var response = await _photoService.DeletePhotoAsync(photoId.PublicId);
                if (response.Error != null) return BadRequest(response.Error.Message);
            }

            userId.Photos.Remove(photoId);
            if (await _userService.SaveAllChangesAsync()) return Ok();

            return BadRequest("Failed to Delete the Photo!! ");
        }


        [HttpPut("set-main-photo/{id}")]

        public async Task<ActionResult> SetMainPhoto(int id)
        {
            var userId = await _userService.GetByIdAsync(User.GetUserId());
            var photoId = userId.Photos.FirstOrDefault(p => p.Id == id);
            if (photoId.IsMain) return BadRequest("This is already Main Photo");
            var currentMain = userId.Photos.FirstOrDefault(x => x.IsMain);
            if (currentMain != null) currentMain.IsMain = false;
            photoId.IsMain = true;
            if (await _userService.SaveAllChangesAsync()) return NoContent();
            return BadRequest("Failed to set Main Photo!!");

        }

    }
}