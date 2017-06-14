using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models
{
    public class ApplicationSearchModel
    {
        public int ApplicationID { get; set; }
        public List<Application> filteredApps { get; set; }
        public List<User> filteredUsers { get; set; }
        public List<ApplicationStatus> filteredAppStatus { get; set; }
        public List<string> filteredGrades { get; set; }
        public List<string> filteredSports { get; set; }
        public List<string> filteredSchools { get; set; }
        public List<string> filteredAreas { get; set; }


        public bool IsChecked { get; set; }
        public List<int> Area { get; set; }
        public List<int> School { get; set; }
        public List<int> Sport { get; set; }
        public List<int> Grade { get; set; }

        public List<Area> allAreas { get; set; }
        public List<School> allSchools { get; set; }
        public List<Sport> allSports { get; set; }
        public List<Grade> allGrades { get; set; }
    }
}
