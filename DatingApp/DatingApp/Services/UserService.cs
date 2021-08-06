using DatingApp.Api.Services.Interfaces;
using DatingApp.DataModel.Entities;
using DatingApp.DataModel.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp.Api.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<bool> SaveAllChangesAsync()
        {
            return await _userRepository.SaveAllChangesAsync();
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }
    }
}
