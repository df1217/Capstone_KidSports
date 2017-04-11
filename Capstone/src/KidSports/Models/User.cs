using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models
{
    public class User
    {
        // primary key for this user in the application database
        public int UserID { get; set; }
        // foreign key for the user in the Identity database
        public string IdUserID { get; set; }

        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string MiddleName { get; set; }
        //public string Email { get; set; }
        //public string UserName { get; set; }

        public List<Application> UserApplications{ get; set; }
    }
}
