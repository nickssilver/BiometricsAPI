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
                //byte[] fingerprintBytes = Convert.FromBase64String(fingerprint);

                BiometricModel? student = _context.Biometrics.FirstOrDefault(b => b.Fingerprint1.SequenceEqual(fingerprintBytes) || b.Fingerprint2.SequenceEqual(fingerprintBytes));

                if (student != null)
                {
                    var log = new AuditLog
                    {
                        StudentId = student.StudentId,
                        StudentName = student.StudentName,
                        VerificationTimestamp = DateTime.UtcNow
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
    }
}
