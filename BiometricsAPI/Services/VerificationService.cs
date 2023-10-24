
using System;
using System.Linq;
using System.Threading.Tasks;
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

        public Biometric VerifyFingerprint(byte[] fingerprint)
        {
            try
            {
                var student = _context.Biometrics.FirstOrDefault(b =>
                    b.Fingerprint1.SequenceEqual(fingerprint) ||
                    b.Fingerprint2.SequenceEqual(fingerprint));

                if (student != null)
                {
                    var log = new AuditLog
                    {
                        StudentId = student.StudentId,
                        StudentName = student.StudentName,
                        Action = "Verification",
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
