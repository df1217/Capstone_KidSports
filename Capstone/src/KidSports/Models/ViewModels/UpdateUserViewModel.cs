using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models.ViewModels
{
    public class UpdateUserViewModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }


        public List<User> allUsers { get; set; }
        public List<string> allRoles { get; set; }


        public string userToDelete { get; set; }
        public string userToUpdate { get; set; }

    }
}
