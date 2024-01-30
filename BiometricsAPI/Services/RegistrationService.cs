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

        public async Task<bool> DeleteStudent(string studentId)
        {
            var student = await _context.Biometrics
                .Where(s => s.StudentId == studentId)
                .FirstOrDefaultAsync();

            if (student == null)
            {
                return false;
            }

            _context.Biometrics.Remove(student);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
