using BiometricsAPI.Models;

namespace BiometricsAPI.Services
{
    // IUserService.cs
    public interface IUserService
    {
        Task<Biousers> CreateUserAsync(Biousers newUser, Permissions permissions);
        Task<Biousers> GetUserAsync(string userId);
        // Add other methods as needed
    }

}


