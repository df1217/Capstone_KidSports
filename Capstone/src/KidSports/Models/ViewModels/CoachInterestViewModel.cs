using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models.ViewModels
{
    public class CoachInterestViewModel
    {
        public string Direction { get; set; }
        public int ApplicationID { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public bool IsHeadCoach { get; set; }
        public Sport Sport { get; set; }

        public Area Area { get; set; }
        public School School { get; set; }

        public string Gender { get; set; }
        public Grade GradePreference{ get; set; }
        public string ChildTeam { get; set; }
       
        public Nullable<bool> IsApproved { get; set; }

        public List<Grade> AllGrades { get; set; }
        public List<Experience> AllExperience { get; set; }

        public bool IsAssistantCoach { get; set; }
       
        public List<Area> AllAreas { get; set; }
        public List<School> SchoolsByArea { get; set; }
        public List<Sport> AllSports { get; set; }
        public int YearsExperience { get; set; }

        public List<Experience> PreviousExperience { get; set; }









    }
}
