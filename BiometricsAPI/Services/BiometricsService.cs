using BiometricsAPI.Data;
using BiometricsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

public class BiometricsService
{
    private readonly BiometricsContext _dbContext;

    public BiometricsService(BiometricsContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Check if a student with the given student number exists in the "Register" table.
    public bool StudentExistsInRegisterTable(int studentNumber)
    {
        return _dbContext.Register.Any(r => r.StudentNumber == studentNumber);
    }

    // Compare the scanned fingerprint with stored fingerprints in the "Biometrics" table.
    public bool AreFingerprintsMatch(int studentNumber, byte[] scannedFingerprint)
    {
        var user = _dbContext.Biometrics
            .FirstOrDefault(b => b.Studen5tNumber == studentNumber);

        if (user == null)
        {
            return false; // User not found in the "Biometrics" table.
        }

        // Implement your fingerprint comparison logic here. Replace this with your actual comparison logic.
        bool fingerprintsMatch = YourFingerprintComparisonLogic(user.Fingerprint1, scannedFingerprint);

        return fingerprintsMatch;
    }

    private bool YourFingerprintComparisonLogic(byte[] storedFingerprint, byte[] scannedFingerprint)
    {
        // Implement your fingerprint comparison logic here.
        // Return true if the fingerprints match, otherwise return false.
        // This logic may involve using a fingerprint recognition library or algorithm.
        return false; // Replace this with your actual logic.
    }

    // Log a failed verification attempt in the "AuditLog" table.
    public void LogFailedVerification(int studentNumber)
    {
        var logEntry = new AuditLog
        {
            Action = "Verification Failed",
            VerificationTimestamp = DateTime.Now,
            // Other fields as needed
        };
        _dbContext.AuditLogs.Add(logEntry);
        _dbContext.SaveChanges();
    }

    // Log a successful verification attempt in the "AuditLog" table.
    public void LogSuccessfulVerification(int studentNumber)
    {
        var logEntry = new AuditLog
        {
            Action = "Verification Successful",
            VerificationTimestamp = DateTime.Now,
            // Other fields as needed
        };
        _dbContext.AuditLogs.Add(logEntry);
        _dbContext.SaveChanges();
    }

    // Register a user in the "Biometrics" table.
    public void RegisterUser(UserData userData)
    {
        _dbContext.Biometrics.Add(userData);
        _dbContext.SaveChanges();
    }
}
