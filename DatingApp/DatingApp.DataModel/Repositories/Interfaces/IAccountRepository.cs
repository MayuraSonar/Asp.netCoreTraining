using DatingApp.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.DataModel.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<User> Register(User user);
        Task<User> Login(string name, string password);
        Task<bool> UserExists(string userName);
    }
}
