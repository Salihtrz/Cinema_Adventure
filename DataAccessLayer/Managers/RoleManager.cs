using DataAccessLayer.Abstraction;
using DataAccessLayer.Context;
using EntityLayer.Class;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Managers
{
    public class RoleManager : IRoleManager<Role>
    {
        CinemaDb CinemaDb = new CinemaDb();
        public void addRole(Role role)
        {
            CinemaDb.Roles.Add(role);
            CinemaDb.SaveChanges();
        }

        public List<Role> GetAllRoles()
        {
            return CinemaDb.Set<Role>().ToList();
        }

        public Role getRoleById(int id)
        {
            return CinemaDb.Roles.Find(id);
        }

        public void removeRole(Role role)
        {
            CinemaDb.Remove(role);
            CinemaDb.SaveChanges();
        }

        public void updateRole(Role role)
        {
            CinemaDb.Update(role);
            CinemaDb.SaveChanges();
        }
    }
}
