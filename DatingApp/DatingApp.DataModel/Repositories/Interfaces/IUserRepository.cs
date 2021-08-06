using DatingApp.DataModel.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp.DataModel.Repositories.Interfaces
{
    public interface IUserRepository
    {
       Task <IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<bool> SaveAllChangesAsync();
        void Update(User user);
    }
}
