using DatingApp.DataModel.Context;
using DatingApp.DataModel.Entities;
using DatingApp.DataModel.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DatingApp.DataModel.Repositories
{
    public class AccountRepository : IAccountRepository
    {

        private readonly DatingAppDbContext _datingAppDbContext;

        public AccountRepository(DatingAppDbContext datingAppDbContext)
        {
            _datingAppDbContext = datingAppDbContext;
        }




        public async Task<User> Register(User user)
        {
            _datingAppDbContext.User.Add(user);
            await _datingAppDbContext.SaveChangesAsync();
            return user;


        }
                public async Task<User> Login(string name, string password)
        {
            var user = await _datingAppDbContext.User.Include(p => p.Photos)
                .FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            return user;
        }

        public async Task<bool> UserExists(string userName)
        {
             return await _datingAppDbContext.User.AnyAsync(u => u.Name.ToLower() == userName.ToLower());
              
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;


        }


    }

}