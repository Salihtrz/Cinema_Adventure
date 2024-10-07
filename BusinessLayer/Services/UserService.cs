using BusinessLayer.Abstraction;
using DataAccessLayer.EntityFramework;
using EntityLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BusinessLayer.Services
{
    public class UserService : IUserService<User>
    {
        EfUser efUser;
        public UserService(EfUser efUser) 
        {
            this.efUser = efUser;
        }
        public void addUser(User user)
        {
            //var encryptedPassword = EncryptionHelper.Encrypt(user.Password , AppConstants.EncryptionKey);
            //user.Password = encryptedPassword;
            efUser.addUser(user);
        }

        public List<User> getAllUsers()
        {
            return efUser.getAllUsers();
        }
        public List<User> getUserWithRole()
        {
            return efUser.getUserWithRole();
        }

        public User getUserById(int id)
        {
            return efUser.getUserById(id);
        }

        public bool IsUserExists(string email)
        {
            return efUser.IsUserExists(email);
        }

        public User Login(string email, string password)
        {
            return efUser.Login(email, password);
        }

        public void removeUser(User user)
        {
            efUser.removeUser(user);
        }

        public void updateUser(User user)
        {
            //var encryptedPassword = EncryptionHelper.Encrypt(user.Password, AppConstants.EncryptionKey);
            //user.Password = encryptedPassword;
            efUser.updateUser(user);
        }
    }
}
