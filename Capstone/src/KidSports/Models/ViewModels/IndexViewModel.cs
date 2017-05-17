using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models.ViewModels
{
    public class IndexViewModel
    {
        public int ApplicationID { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public Application Application { get; set; }
        public string PageName { get; set; }
        public string UserFirstName { get; set; }
    }
}