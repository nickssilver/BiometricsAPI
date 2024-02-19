using BiometricsAPI.Data;
using BiometricsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiometricsAPI.Services
{
    public class UserService : IUserService
    {
        private readonly BiometricsContext _context;

        public UserService(BiometricsContext context)
        {
            _context = context;
        }

        public async Task<Biousers> RegisterUserAsync(Biousers newUser, List<Permissions> selectedPermissions)
        {
            if (await IsUserIdUnique(newUser.UserId) && await IsPinUnique(newUser.Pin))
            {
                // Combine the selected permissions into a single Permissions value
                Permissions permissions = Permissions.None;
                foreach (var permission in selectedPermissions)
                {
                    permissions |= permission;
                }

                newUser.Permissions = permissions;
                _context.Biousers.Add(newUser);
                await _context.SaveChangesAsync();
                return newUser;
            }
            return null;
        }

        public async Task<Biousers> AuthenticateUserAsync(string pin)
        {
            return await _context.Biousers.FirstOrDefaultAsync(u => u.Pin == pin);
        }

        public async Task<IEnumerable<Biousers>> GetAllUsersAsync()
        {
            return await _context.Biousers.ToListAsync();
        }

        public async Task<Biousers> GetUserByIdAsync(string id)
        {
            return await _context.Biousers.FindAsync(id);
        }

        private async Task<bool> IsUserIdUnique(string userId)
        {
            return !await _context.Biousers.AnyAsync(u => u.UserId == userId);
        }

        private async Task<bool> IsPinUnique(string pin)
        {
            return !await _context.Biousers.AnyAsync(u => u.Pin == pin);
        }

        // Implement other methods as needed
    }
}
