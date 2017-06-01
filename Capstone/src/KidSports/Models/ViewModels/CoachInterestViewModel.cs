using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models.ViewModels
{
    public class CoachInterestViewModel
    {
        public string Direction { get; set; }
        public int ApplicationID { get; set; }
        public bool IsHeadCoach { get; set; }
        public Sport Sport { get; set; }

        public Area Area { get; set; }
        public School School { get; set; }

        public string Gender { get; set; }
        public string GradePreference{ get; set; }
        [RegularExpression("^([A-Z]{1}[a-zA-Z ]*$)", ErrorMessage = "Name must be capitalized and not contain any digits or special characters")]
        public string ChildTeam { get; set; }

        public List<Grade> AllGrades { get; set; }
        public List<Experience> AllExperience { get; set; }

        public bool IsAssistantCoach { get; set; }
       
        public List<Area> AllAreas { get; set; }
        public List<School> SchoolsByArea { get; set; }
        public List<Sport> AllSports { get; set; }
        public int YearsExperience { get; set; }

        public List<Experience> PreviousExperience { get; set; }
        public int newPickedAreaID { get; set; }
        public int newPickedSchoolID { get; set; }
        public int newPickedSportID { get; set; }
    }
}
