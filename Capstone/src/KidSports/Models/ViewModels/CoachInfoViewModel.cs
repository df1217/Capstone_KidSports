using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models.ViewModels
{
    public class CoachInfoViewModel
    {
        public string Direction { get; set; }
        public int ApplicationID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PreviousLastName1 { get; set; }
        public string PreviousLastName2 { get; set; }
        public string PreviousLastName3 { get; set; }
        public List<State> AllStates { get; set; }
        public string PreferredName { get; set; }
        [DataType(DataType.Date)]
        public Nullable<DateTime> DOB { get; set; }
        public int YearsLivingInOregon { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public int newPickedStateID { get; set; }
        public string Zip { get; set; }
        public List<int> PreviousStates { get; set; }
        public bool HasLivedOutsideUSA { get; set; }
        public string AlternatePhone { get; set; }
        public string CellPhone { get; set; }
        public string CurrentEmployer { get; set; }
        public string JobTitle { get; set; }
    }
}
