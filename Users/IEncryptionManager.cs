using System;

namespace Contracts
{
    public interface IEncryptionManager
    {
        String createSalt();
        String createHash(String password, String salt);
        bool verifyPassword(String saltedPassword, String dbPassword);
    }
}
