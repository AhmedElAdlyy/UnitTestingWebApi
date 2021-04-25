using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiTesting.Models;

namespace WebApiTesting.Services
{
    public class RoleDb : IRoles
    {
        private TestingContext _context;

        public RoleDb(TestingContext context)
        {
            this._context = context;
        }

        public Role AddRole(Role role)
        {
            _context.Role.Add(role);
            _context.SaveChanges();

            return role;
        }

        public bool DeleteRoleById(int id)
        {
            Role role = GetRole(id);
            bool operation = DeleteRoleByRole(role);

            return operation;
        }

        public bool DeleteRoleByRole(Role role)
        {
            try
            {
                _context.Role.Remove(role);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public Role EditRole(Role newRoleData)
        {
            _context.Entry(newRoleData).State = EntityState.Modified;
            _context.SaveChanges();

            return newRoleData;
        }

        public Role GetRole(int id)
        {
            return _context.Role.Find(id);
        }

        public List<Role> GetRoles()
        {
            return _context.Role.ToList();
        }
    }
}