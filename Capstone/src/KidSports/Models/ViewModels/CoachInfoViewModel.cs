
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models.ViewModels
{
    public class CoachInfoViewModel
    {
        public int ApplicationID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public LastName PreviousLastName1 { get; set; }
        public LastName PreviousLastName2 { get; set; }
        public LastName PreviousLastName3 { get; set; }



        public List<LastName> PreviousLastNames { get; set; }
        public string PreferredName { get; set; }
        public DateTime DOB { get; set; }
        public int YearsLivingInOregon { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string Zip { get; set; }
        public List<State> PreviousStates { get; set; }

        public string CellPhone{ get; set; }
        public string AlternatePhone { get; set; }
        public string CurrentEmployer { get; set; }
        public string JobTitle { get; set; }
        public Nullable<bool> IsApproved { get; set; }














    }
}
