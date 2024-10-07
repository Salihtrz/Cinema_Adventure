using DataAccessLayer.Abstraction;
using DataAccessLayer.Context;
using EntityLayer.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Utilities;

namespace DataAccessLayer.Managers
{
    public class UserManager : IUserManager<User>
    {
        CinemaDb CinemaDb = new CinemaDb();
        public void addUser(User user)
        {
            var encryptedPassword = EncryptionHelper.Encrypt(user.Password, AppConstants.EncryptionKey);
            user.Password = encryptedPassword;
            CinemaDb.Add(user);
            CinemaDb.SaveChanges();
        }

        public List<User> getAllUsers()
        {
            return CinemaDb.Set<User>().ToList();
        }

        public User getUserById(int id)
        {
            var FindRole = CinemaDb.Set<User>().Include(i => i.roles).FirstOrDefault(x => x.UserID == id);
            return FindRole;
        }

        public List<User> getUserWithRole()
        {
            return CinemaDb.Set<User>().Include(i => i.roles).ToList();
        }

        public bool IsUserExists(string email)
        {
            var user = CinemaDb.Users.FirstOrDefault(i => i.UserEmail  == email);
            return user != null;
        }

        public User Login(string email, string password)
        {
            User user = null;
            var encryptedPassword = EncryptionHelper.Encrypt(password, AppConstants.EncryptionKey);
            //var user = CinemaDb.Login(email, encryptedPassword);
            using (var db = new CinemaDb())
            {
                user = db.Users.Include(i => i.roles).FirstOrDefault(i => i.UserEmail == email && i.Password == encryptedPassword);
            }
            return user;
        }

        public void removeUser(User user)
        {
            CinemaDb.Remove(user);
            CinemaDb.SaveChanges();
        }

        public void updateUser(User user)
        {
			if (!IsBase64String(user.Password))
			{
				var encryptedPassword = EncryptionHelper.Encrypt(user.Password, AppConstants.EncryptionKey);
				user.Password = encryptedPassword;
			}
			CinemaDb.Update(user);
            CinemaDb.SaveChanges();
        }
		private bool IsBase64String(string s)
		{
			s = s.Trim();
			return (s.Length >= 23) && (s.Length % 4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
		}
	}
}
