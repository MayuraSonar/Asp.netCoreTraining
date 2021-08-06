using DatingApp.DataModel.Context;
using DatingApp.DataModel.Entities;
using DatingApp.DataModel.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.DataModel.Repositories
{
    public class UserRepository:IUserRepository
    {

        private readonly DatingAppDbContext _datingAppDbcontext;

        public UserRepository(DatingAppDbContext datingAppDbContext)
        {
            _datingAppDbcontext = datingAppDbContext;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _datingAppDbcontext.User.Include(x=>x.Photos).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _datingAppDbcontext.User.Where(u=> u.Id == id).Include(x=>x.Photos).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAllChangesAsync()
        {
            return await _datingAppDbcontext.SaveChangesAsync() > 0;
        }

        public void Update(User user)
        {
            _datingAppDbcontext.Entry(user).State = EntityState.Modified;
        }
    }
}
