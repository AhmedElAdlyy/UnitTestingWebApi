namespace WebApiTesting.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApiTesting.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApiTesting.Models.TestingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApiTesting.Models.TestingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            User user = new User
            {
                Username = "Admin",
                Password = "123",
                Email = "admin@admin.com",
            };

            Role role = new Role
            {
                RoleName = "Admin"
            };

            context.User.Add(user);
            context.Role.Add(role);

            User_Role user_role = new User_Role
            {
                UserId = user.Id,
                RoleId = role.Id
            };

            context.User_Role.Add(user_role);
        }
    }
}
