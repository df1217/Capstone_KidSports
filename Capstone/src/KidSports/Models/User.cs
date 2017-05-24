using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PreferredName { get; set; }
        public List<Application> UserApplications{ get; set; }
        public Application currentYearApp { get; set; }
        public string AlternatePhone { get; set; }
        public string PreviousLastName1 { get; set; }
        public string PreviousLastName2 { get; set; }
        public string PreviousLastName3 { get; set; }

    }
}
