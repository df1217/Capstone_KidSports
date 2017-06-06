using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace KidSports.Models.ViewModels
{
    public class UpdateAppContentViewModel
    {
        public string addSport { get; set; }
        public int deleteSport { get; set; }

        public string addArea { get; set; }
        public int deleteArea { get; set; }

        public string addSchool { get; set; }
        public int deleteSchool { get; set; }

        public string Action { get; set; }

        public Area AreaName { get; set; }
        public School SchoolName { get; set; }
        public Sport SportName { get; set; }

        public List<Area> AllAreas { get; set; }
        public List<School> AllByArea { get; set; }
        public List<Sport> AllSports { get; set; }
        public List<School> AllSchools { get; set; }
    }

}
