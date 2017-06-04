using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace KidSports.Models.ViewModels
{
    public class UpdateAppContentViewModel
    {
        string addSport;
        int deleteSport;

        string addArea;
        int deleteArea;

        string addSchool;
        int deleteSchool;

        string action;

        public Area AreaName { get; set; }
        public School SchoolName { get; set; }
        public Sport SportName { get; set; }

        public List<Area> AllAreas { get; set; }
        public List<School> AllByArea { get; set; }
        public List<Sport> AllSports { get; set; }

    }

}
