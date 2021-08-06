using DatingApp.DataModel.Entities;

using System.Collections.Generic;

using System.Threading.Tasks;

namespace DatingApp.Api.Services.Interfaces
{
  public  interface IUserService
    {
        void Update(User user);
        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetByIdAsync(int id);
        Task<bool> SaveAllChangesAsync();
    }
}
