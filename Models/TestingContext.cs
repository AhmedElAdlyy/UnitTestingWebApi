using System;
using System.Data.Entity;
using System.Linq;

namespace WebApiTesting.Models
{
    public class TestingContext : DbContext
    {
        // Your context has been configured to use a 'TestingContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WebApiTesting.Models.TestingContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TestingContext' 
        // connection string in the application configuration file.
        public TestingContext()
            : base("name=TestingContext")
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User_Role> User_Role { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}