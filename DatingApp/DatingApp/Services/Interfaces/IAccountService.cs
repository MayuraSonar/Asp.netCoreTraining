using DatingApp.DataModel.Entities;
using System.Threading.Tasks;

namespace DatingApp.Api.Services.Interfaces
{
    public  interface IAccountService
    {
        Task<User> Register(string name,string password,string gender);
        Task<User> Login(string name, string password);
        Task<bool> UserExists(string userName);
    }
}
