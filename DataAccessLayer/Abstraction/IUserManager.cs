using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstraction
{
    public interface IUserManager<User>
    {
        void addUser(User user);
        void removeUser(User user);
        void updateUser(User user);
        List<User> getAllUsers();
        User getUserById(int id);
        User Login(string email, string password);
        bool IsUserExists(string email);
        List<User> getUserWithRole();
    }
}
