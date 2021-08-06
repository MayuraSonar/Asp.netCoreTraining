using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DatingApp.Api.Services.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile fromFile);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
