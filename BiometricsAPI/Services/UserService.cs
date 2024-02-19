using BiometricsAPI.Data;
using BiometricsAPI.Models;

namespace BiometricsAPI.Services
{
    // UserService.cs
    public class UserService : IUserService
    {
        private readonly BiometricsContext _context;

        public UserService(BiometricsContext context)
        {
            _context = context;
        }

        public async Task<Biousers> CreateUserAsync(Biousers newUser, Permissions permissions)
        {
            newUser.Permissions = permissions;
            _context.Biousers.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<Biousers> GetUserAsync(string userId)
        {
            return await _context.Biousers.FindAsync(userId);
        }

        // Implement other methods as defined in the interface
    }
}

