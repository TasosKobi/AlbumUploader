using Entities.Models;

namespace Contracts
{
    public interface ITokenManager
    {
        string CreateToken(User user);
        User GetUser(string token);
    }
}
