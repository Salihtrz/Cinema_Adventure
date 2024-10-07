using BusinessLayer.Abstraction;
using DataAccessLayer.EntityFramework;
using EntityLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class RoleService : IRoleService<Role>
    {
        EFRole efRole;
        public RoleService(EFRole efRole) 
        {
            this.efRole = efRole;
        }
        public void addRole(Role role)
        {
            efRole.addRole(role);
        }

        public List<Role> GetAllRoles()
        {
            return efRole.GetAllRoles();
        }

        public Role GetRoleById(int id)
        {
            return efRole.getRoleById(id);
        }

        public void removeRole(Role role)
        {
            efRole.removeRole(role);
        }

        public void updateRole(Role role)
        {
            efRole.updateRole(role);
        }
    }
}
