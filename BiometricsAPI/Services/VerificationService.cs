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

        public BiometricModel VerifyFingerprint(byte[] fingerprintBytes)
        
        {
            try
            {
            
                BiometricModel? student = _context.Biometrics.FirstOrDefault(b => b.Fingerprint1.SequenceEqual(fingerprintBytes) || b.Fingerprint2.SequenceEqual(fingerprintBytes));

                if (student != null)
                {
                    var log = new AuditLogs
                    {
                        StudentId = student.StudentId,
                        StudentName = student.StudentName,
                        VerificationTimestamp = DateTime.UtcNow.AddHours(3)
                    };

                    _context.AuditLogs.Add(log);
                    _context.SaveChanges();
                }

                return student;
            }
            catch (Exception)
            {
                return null;
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