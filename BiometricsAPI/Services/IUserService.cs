﻿using BiometricsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiometricsAPI.Services
{
    public interface IUserService
    {
        Task<Biousers> RegisterUserAsync(Biousers newUser, List<bool> permissions);
        Task<Biousers> AuthenticateUserAsync(string pin);
        Task<IEnumerable<Biousers>> GetAllUsersAsync();
        Task<Biousers> GetUserByIdAsync(string id);
        Task<Biousers> EditUserAsync(string id, Biousers updatedUser);
        Task<bool> DeleteUserAsync(string id);
    }
}
