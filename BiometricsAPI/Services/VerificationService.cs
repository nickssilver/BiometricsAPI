using System;
using System.Linq;
using BiometricsAPI.Data;
using BiometricsAPI.Models;

namespace BiometricsAPI.Services
{
    public class VerificationService
    {
        private readonly BiometricsContext _context;

        public VerificationService(BiometricsContext context)
        {
            _context = context;
        }

        public void VerifyFingerprint(AuditLogs log)
        {
            try
            {
                var auditLog = new AuditLogs
                {
                    StudentId = log.StudentId,
                    StudentName = log.StudentName,
                    VerificationTimestamp = DateTime.UtcNow.AddHours(3)
                };

                _context.AuditLogs.Add(auditLog);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<BiometricModel> GetAllFingerprintTemplates()
        {
            try
            {
                var templates = _context.Biometrics.ToList();
                return templates;
            }
            catch (Exception)
            {
                return null;
            }
        }



    }
}