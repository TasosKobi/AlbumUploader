using System;
using System.Security.Cryptography;
using Contracts;

namespace EncryptionService
{
    public class EncryptionManager : IEncryptionManager 
    {

        public EncryptionManager()
        {
        }

        public String  createSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[32];
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }
        
        public String createHash(String password, String salt)
        {
            String passwordHash = BCrypt.Net.BCrypt.HashPassword(password + salt);
            return passwordHash;
        }
        public bool verifyPassword(String saltedPassword , String dbPassword)
        {
            return BCrypt.Net.BCrypt.Verify(saltedPassword, dbPassword);
        }
    }
}
