using BiometricsAPI.Data;

namespace BiometricsAPI.Services
{
    public class RegistrationService
    {
        private readonly BiometricsContext _context;

        public RegistrationService(BiometricsContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterStudent(BiometricModel model)
        {
            try
            {
                _context.Biometrics.Add(model);
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

