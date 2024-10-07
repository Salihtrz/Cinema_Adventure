using EntityLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstraction
{
	public interface IRoleService<Role>
	{
		List<Role> GetAllRoles();
		void addRole (Role role);
		void removeRole (Role role);
		void updateRole (Role role);
		Role GetRoleById (int id);
	}
}
