using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebApiTesting.Services;
using WebApiTesting.Models;

namespace Repos.UnitTest
{
    [TestClass]
    public class UnitTest1
    {

        private UserDb userDb = new UserDb(new TestingContext());
        private RoleDb roleDb = new RoleDb(new TestingContext());
        private User_RoleDb userRoleDb = new User_RoleDb(new TestingContext());

        [TestMethod]
        public void SeedTestTrue()
        {
            bool check = false;
            int userId;
            int roleId;

            User user = userDb.GetUserByName("Admin");

            if(user != null) 
            {
                userId = user.Id;

                Role role = roleDb.GetRoleByName("Admin");

                if(role != null)
                {
                    roleId = role.Id;

                    User_Role userRole = userRoleDb.Get_UserRole(userId, roleId);

                    if(userRole != null)
                    {
                        check = true;
                    }
                }
            }

            Assert.IsTrue(check);

        }
    }
}
