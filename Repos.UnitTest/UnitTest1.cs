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

        [TestMethod]
        public void LoginTestTrue()
        {
            var user = userDb.LoginUser("Admin", "123");

            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void LoginTestFalse()
        {
            var user = userDb.LoginUser("Admins", "1234");

            Assert.IsNull(user);
        }

        // next 6 funtions instead of first function in this class

        [TestMethod]
        public void UserSeedTestTrue()
        {
            var user = userDb.GetUserByName("Admin");
            
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void UserSeedTestFalse()
        {
            var user = userDb.GetUserByName("Admins");
            Assert.IsNull(user);
        }

        [TestMethod]
        public void RoleSeedTestTrue()
        {
            var role = roleDb.GetRoleByName("Admin");
            Assert.IsNotNull(role);
        }

        [TestMethod]
        public void RoleSeedTestFalse()
        {
            var role = roleDb.GetRoleByName("Admins");
            Assert.IsNull(role);
        }


        [TestMethod]
        public void UserRoleSeedTestTrue()
        {
            User user = userDb.GetUserByName("Admin");
            Role role = roleDb.GetRoleByName("Admin");

            User_Role userRole = userRoleDb.Get_UserRole(user.Id , role.Id);
            Assert.IsNotNull(userRole);
        }

        [TestMethod]
        public void UserRoleSeedTestFalse()
        {
            User_Role userRole = null;

            User user = userDb.GetUserByName("Admins");
            Role role = roleDb.GetRoleByName("Admins");

            if(user !=null && role != null)
            {
                userRole = userRoleDb.Get_UserRole(user.Id, role.Id);
            }

            Assert.IsNull(userRole);
        }



    }
}
