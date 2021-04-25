using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTesting.Models;

namespace Repos
{
    class User_RoleDb : IUser_Roles
    {
        private TestingContext _context;

        public User_RoleDb(TestingContext context)
        {
            this._context = context;
        }

        public User_Role AddUserRole(int userId, int roleId)
        {
            User_Role user_Role = new User_Role
            {
                RoleId = roleId,
                UserId = userId
            };

            _context.User_Role.Add(user_Role);
            _context.SaveChanges();

            return user_Role;


        }

        public bool DeleteUserRole(User_Role user_Role)
        {
            try
            {
                _context.User_Role.Remove(user_Role);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public User_Role EditUserRole(User_Role user_Role)
        {
            _context.Entry(user_Role).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

            return user_Role;
        }

        public List<User_Role> GetUser_Roles()
        {
            return _context.User_Role.ToList();
        }

        public User_Role Get_UserRole(int userId, int roleId)
        {
            return _context.User_Role.FirstOrDefault(f => f.RoleId == roleId && f.UserId == userId);
        }
    }
}
