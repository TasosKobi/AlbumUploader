using Entities;
using Entities.Models;
using Contracts;
using System.Collections.Generic;
using System.Linq;
using EncryptionService;
using System.Security.Cryptography;
using System;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        IEncryptionManager encryptionManager = new EncryptionManager() ;

        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<User> GetAllUsers()
        {
            return FindAll().OrderBy(ow => ow.Email);
        } 

        public User FindByEmail(string email)
        {
            IEnumerable<User> user = FindByCondition(a => a.Email.Equals(email));
            if (user.Count<User>() == 0)
            {
                User dummy = new User();
                return dummy;
            }
            return user.First<User>();
        }

        public User CreateUser(User user)   
        {
            user.Salt  = encryptionManager.createSalt();
            user.Password = encryptionManager.createHash(user.Password, user.Salt);
            Create(user);
            Save();
            return user;
        }
        public bool Exists(string email)
        {
            var user = FindByEmail(email);

            if (user.Id !=  0)
            {
                return true;
            }
                return false;
        }

        public bool PasswordIsValid(User user)
        {
            User DbUser = FindByEmail(user.Email);
            string SaltedPassword = user.Password + DbUser.Salt;

            return (encryptionManager.verifyPassword(SaltedPassword, DbUser.Password));

        }
        public void Logout(User user)
        {
            user.IsLoggedIn = false;
            Update(user);
        }
        public void IsLogin(User user)
        {
            user.IsLoggedIn = true;
            Update(user);
        }

    }
}
