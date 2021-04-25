using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiTesting.Models
{
    public class User_Role
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }


        //Relations

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}