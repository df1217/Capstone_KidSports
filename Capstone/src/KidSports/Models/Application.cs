using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models
{
    public class Application
    {
        public int ApplicationID { get; set; }
        public List<string> StatesLived { get; set; }
        public List<string> CountriesLived { get; set; }
        public List<string> PreviousLastNames { get; set; }


        public string BackgroundRequest { get; set; }

        public string BackgroundResult { get; set; }
        public DateTime DOB { get; set; }

        public string CurrentEmployer { get; set; }
        public string JobTitle { get; set; }

        public string Address { get; set; }
        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public School AppSchool { get; set; }
        public Sport AppSport { get; set; }

        public List<Area> Region { get; set; }

    }
}
