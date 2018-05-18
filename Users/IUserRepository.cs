using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IEnumerable<User> GetAllUsers();
        User FindByEmail(string email);
        User CreateUser(User user);
        bool PasswordIsValid(User user);
        bool Exists(string email);
        void Logout(User user);
        void IsLogin(User user);
    }
}
