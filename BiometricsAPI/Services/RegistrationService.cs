using AutoMapper;
using BiometricsAPI.Data;
using BiometricsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BiometricsAPI.Services
{
    public class RegistrationService
    {
        private readonly BiometricsContext _context;
        private readonly IMapper _mapper;

        public RegistrationService(BiometricsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async Task<StudentModel> GetStudentData(string studentId)
        {
            var studentData = await _context.Register
                .Where(s => s.AdmnNo == studentId)
                .FirstOrDefaultAsync();

            return _mapper.Map<StudentModel>(studentData);
        }
    }
}
