using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DatingApp.DataModel.Repositories.Interfaces
{
    public interface IPhotoRepository
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile fromFile);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
