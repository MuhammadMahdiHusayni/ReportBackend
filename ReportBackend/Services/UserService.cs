using Microsoft.EntityFrameworkCore;
using ReportBackend.Data;
using ReportBackend.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ReportBackend.Services
{
    public class UserService : IUserService
    {
        private readonly ReportingContext _context;

        public UserService(ReportingContext context)
        {
            _context = context;
        }

        public async Task<bool> AddUserAsync(NewUser newUser)
        {
            var entity = new User
            {
                UserId = Guid.NewGuid(),
                Email = newUser.Email,
                Name = newUser.Name
            };
            _context.Users.Add(entity);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _context.Users
                 .Where(x => x.Email == email)
                 .SingleOrDefaultAsync();
        }
    }
}
