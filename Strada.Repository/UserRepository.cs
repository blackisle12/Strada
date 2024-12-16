using Microsoft.EntityFrameworkCore;
using Strada.Repository.Interface;
using Strada.Repository.Models;

namespace Strada.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> EmailExistsAsync(string email, int id = 0)
        {
            return await _context.Users.AnyAsync(u => u.Email != null && u.Email.ToLower() == email.ToLower() && u.Id != id);
        }
    }
}
