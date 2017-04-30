using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models.ViewModels
{
    public class CoachInterestViewModel
    {
        public bool IsHeadCoach { get; set; }
        public Sport Sport { get; set; }
       
        public Area Area { get; set; }
        public School School { get; set; }

        public string Gender { get; set; }
        public Nullable<int> GradePreference{ get; set; }
        public string ChildTeam { get; set; }
        public Nullable<int> YearsCoached { get; set; }
        public Nullable<int> GradesCoached { get; set; }








    }
}
