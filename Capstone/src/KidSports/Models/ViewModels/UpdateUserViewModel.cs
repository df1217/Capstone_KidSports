using KidSports.Repositories;
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
        public UserRole Role { get; set; }
        public string Area { get; set; }

       
        

       

    }
}
