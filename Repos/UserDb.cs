using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiTesting.Models;

namespace WebApiTesting.Services
{
    public class UserDb : IUsers
    {
        private TestingContext _context;

        public UserDb(TestingContext context)
        {
            this._context = context;
        }
        public User AddUser(User user)
        {
            _context.User.Add(user);
            return user;
        }

        public User GetUserByName(string name)
        {
            return _context.User.FirstOrDefault(f => f.Username == name);
        }

        public bool DeleteUserById(int id)
        {
            User user = GetUser(id);
            bool operation = DeleteUserByUser(user);

            return operation;

        }

        public bool DeleteUserByUser(User user)
        {
            try
            {
                _context.User.Remove(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public User EditUser(User newUserData)
        {
            _context.Entry(newUserData).State = EntityState.Modified;
            _context.SaveChanges();
            return newUserData;
        }

        public User GetUser(int id)
        {
            return _context.User.Find(id);
        }

        public List<User> GetUsers()
        {
            return _context.User.ToList();
        }
    }
}