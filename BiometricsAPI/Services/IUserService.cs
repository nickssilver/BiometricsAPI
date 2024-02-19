
using BiometricsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiometricsAPI.Services
{
    public interface IUserService
    {
        Task<Biousers> RegisterUserAsync(Biousers newUser, List<Permissions> permissions);
        Task<Biousers> AuthenticateUserAsync(string pin); // Changed to accept Pin
        Task<IEnumerable<Biousers>> GetAllUsersAsync();
        Task<Biousers> GetUserByIdAsync(string id);
    }
}