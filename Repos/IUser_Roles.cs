using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTesting.Models;

namespace Repos
{
    public interface IUser_Roles
    {
        List<User_Role> GetUser_Roles();
        User_Role Get_UserRole(int userId, int roleId);
        User_Role AddUserRole(int userId, int roleId);
        User_Role EditUserRole(User_Role user_Role);
        bool DeleteUserRole(User_Role user_Role);
    }
}
