
using System;
using System.Threading.Tasks;
using BiometricsAPI.Data;
using BiometricsAPI.Models;

namespace BiometricsAPI.Services
{
    public class RegistrationService
    {
        private readonly BiometricsContext _context;

        public RegistrationService(BiometricsContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterStudent(Biometric model)
        {
            try
            {
                await _context.Biometrics.AddAsync(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

