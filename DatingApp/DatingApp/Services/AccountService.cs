using DatingApp.Api.Services.Interfaces;
using DatingApp.DataModel.Entities;
using DatingApp.DataModel.Repositories.Interfaces;
using System.Threading.Tasks;

namespace DatingApp.Api.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRespository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRespository = accountRepository;
        }
        public async Task<User> Login(string name, string password)
        {
            return await _accountRespository.Login(name, password);
        }

        public async Task<User> Register(string name, string password, string gender)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Name = name,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Gender = gender

            };
            return await _accountRespository.Register(user);
            
        }

        public async Task<bool> UserExists(string userName)
        {
            return await _accountRespository.UserExists(userName);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
    }
}
