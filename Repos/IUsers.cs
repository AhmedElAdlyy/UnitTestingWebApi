using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTesting.Models;

namespace WebApiTesting.Services
{
    public interface IUsers
    {
        List<User> GetUsers();
        User GetUser(int id);
        User GetUserByName(string name);
        User AddUser(User user);
        User EditUser(User newUserData);
        bool DeleteUserById(int id);
        bool DeleteUserByUser(User user);
    }
}
