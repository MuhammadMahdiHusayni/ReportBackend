using ReportBackend.Models;
using System;
using System.Threading.Tasks;

namespace ReportBackend.Services
{
    public interface IUserService
    {
        Task<bool> AddUserAsync(NewUser newUser);
        Task<User> GetUserAsync(string email);
    }
}
