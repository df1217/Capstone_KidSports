using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models.ViewModels
{
    public class UpdateProfile
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public Area AreaName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
