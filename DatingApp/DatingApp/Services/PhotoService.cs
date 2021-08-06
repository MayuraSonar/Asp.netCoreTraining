using CloudinaryDotNet.Actions;
using DatingApp.Api.Services.Interfaces;
using DatingApp.DataModel.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DatingApp.Api.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photorepository;
        public PhotoService(IPhotoRepository photoRepository)
        {
            _photorepository = photoRepository;
        }
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile formFile)
        {
            return await _photorepository.AddPhotoAsync(formFile);
        }

        public async  Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            return await _photorepository.DeletePhotoAsync(publicId);
        }
    }
}
