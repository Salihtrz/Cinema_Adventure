using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstraction
{
    public interface IRoleManager<Role>
    {
        List<Role> GetAllRoles();
        void addRole (Role role);
        void removeRole (Role role);
        void updateRole (Role role);
        Role getRoleById (int id);
    }
}
