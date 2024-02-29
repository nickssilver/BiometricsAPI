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

        public async Task<Biousers> RegisterUserAsync(Biousers newUser, List<bool> selectedPermissions)
        {
            if (await IsUserIdUnique(newUser.UserId) && await IsPinUnique(newUser.Pin))
            {
                // Set permissions based on the provided list
                newUser.RegisterPermission = selectedPermissions[0];
                newUser.VerifyPermission = selectedPermissions[1];
                newUser.RefactorPermission = selectedPermissions[2];
                newUser.AnalyticsPermission = selectedPermissions[3];
                newUser.ManagementPermission = selectedPermissions[4];

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
            return await _context.Biousers.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<Biousers> EditUserAsync(string id, Biousers updatedUser)
        {
            var existingUser = await _context.Biousers.FirstOrDefaultAsync(u => u.UserId == id);
            if (existingUser == null)
                return null;

            existingUser.Name = updatedUser.Name;
            existingUser.Department = updatedUser.Department;
            existingUser.Pin = updatedUser.Pin;
            existingUser.Contact = updatedUser.Contact;
            existingUser.RegisterPermission = updatedUser.RegisterPermission;
            existingUser.VerifyPermission = updatedUser.VerifyPermission;
            existingUser.RefactorPermission = updatedUser.RefactorPermission;
            existingUser.AnalyticsPermission = updatedUser.AnalyticsPermission;
            existingUser.ManagementPermission = updatedUser.ManagementPermission;

            try
            {
                await _context.SaveChangesAsync();
                return existingUser;
            }
            catch (Exception ex)
            {
                // Handle exception
                return null;
            }
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var userToDelete = await _context.Biousers.FirstOrDefaultAsync(u => u.UserId == id);
            if (userToDelete == null)
                return false;

            _context.Biousers.Remove(userToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<bool> IsUserIdUnique(string userId)
        {
            return !await _context.Biousers.AnyAsync(u => u.UserId == userId);
        }

        private async Task<bool> IsPinUnique(string pin)
        {
            return !await _context.Biousers.AnyAsync(u => u.Pin == pin);
        }
    }
}
