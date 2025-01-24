using CatalogManagement.Models.Entities;
using CatalogManagement.Models.GeneralRepository;
using MenuManager.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace CatalogManagement.Models.Repositories
{
    public class UserRepository : GeneralRepository<User>
    {
        public UserRepository(MyDbContext _context) : base(_context) { }

        public async Task<bool> UserExistsByUsername(string username)
        {
            return await _context.Users.AnyAsync(c => c.Username == username);
        }

        public async Task<bool> UserExistsByEmail(string email)
        {
            return await _context.Users.AnyAsync(c => c.Email == email);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Username == username);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Email == email);
        }
    }
}