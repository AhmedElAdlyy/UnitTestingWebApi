using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTesting.Models;

namespace WebApiTesting.Services
{
    public interface IRoles
    {
        List<Role> GetRoles();
        Role GetRole(int id);
        Role GetRoleByName(string name);
        Role AddRole(Role role);
        Role EditRole(Role newRoleData);
        bool DeleteRoleById(int id);
        bool DeleteRoleByRole(Role role);
    }
}
