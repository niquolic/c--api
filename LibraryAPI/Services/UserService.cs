using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class UserService
    {
        private readonly LibraryContext _context;

        public UserService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<User>> GetUsersAsync()
        {
            return _context.Users.AsQueryable();
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                throw new Exception("User not found");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
