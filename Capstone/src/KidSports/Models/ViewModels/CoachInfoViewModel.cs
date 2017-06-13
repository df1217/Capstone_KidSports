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
        [StringLength(20, ErrorMessage = "Name must be less than 20 characters")]
        [RegularExpression("^([A-Z]{1}[a-zA-Z ]*$)", ErrorMessage = "Name must be capitalized and not contain any digits or special characters")]
        public string FirstName { get; set; }
        [StringLength(20, ErrorMessage = "Name must be less than 20 characters")]
        [RegularExpression("^([A-Z]{1}[a-zA-Z ]*$)", ErrorMessage = "Name must be capitalized and not contain any digits or special characters")]
        public string MiddleName { get; set; }
        [StringLength(20, ErrorMessage = "Name must be less than 20 characters")]
        [RegularExpression("^([A-Z]{1}[a-zA-Z ]*$)", ErrorMessage = "Name must be capitalized and not contain any digits or special characters")]
        public string LastName { get; set; }
        [StringLength(20, ErrorMessage = "Name must be less than 20 characters")]
        [RegularExpression("^([A-Z]{1}[a-zA-Z ]*$)", ErrorMessage = "Name must be capitalized and not contain any digits or special characters")]
        public string PreviousLastName1 { get; set; }
        [StringLength(20, ErrorMessage = "Name must be less than 20 characters")]
        [RegularExpression("^([A-Z]{1}[a-zA-Z ]*$)", ErrorMessage = "Name must be capitalized and not contain any digits or special characters")]
        public string PreviousLastName2 { get; set; }
        [StringLength(20, ErrorMessage = "Name must be less than 20 characters")]
        [RegularExpression("^([A-Z]{1}[a-zA-Z ]*$)", ErrorMessage = "Name must be capitalized and not contain any digits or special characters")]

        public string PreviousLastName3 { get; set; }
        public List<State> AllStates { get; set; }
        [StringLength(20, ErrorMessage = "Name must be less than 20 characters")]
        [RegularExpression("^([A-Z]{1}[a-zA-Z ]*$)", ErrorMessage = "Name must be capitalized and not contain any digits or special characters")]
        public string PreferredName { get; set; }
        [DataType(DataType.Date)]


        //TODO: Validation?? I deleted a commented out piece of validation during merge, unsure if it was important.
        public DateTime? DOB { get; set; }

        public int YearsLivingInOregon { get; set; }
        [StringLength(50, ErrorMessage = "Name must be less than 50 characters")]
        [RegularExpression("[A-za-z0-9 #.-]*$", ErrorMessage ="Invalid Address test")]
        public string Address { get; set; }
        [StringLength(20, ErrorMessage = "City must be less than 20 characters")]
        [RegularExpression("^([A-Z]{1}[a-zA-Z ]*$)", ErrorMessage = "City must be capitalized and not contain any digits or special characters")]

        public string City { get; set; }
        public State State { get; set; }
        public int newPickedStateID { get; set; }
        [RegularExpression("^[0-9]{5}$", ErrorMessage = "Enter Valid 5 digit zipcode")]
        public string Zip { get; set; }
        public List<int> PreviousStates { get; set; }
        public bool HasLivedOutsideUSA { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone number")]
        public string AlternatePhone { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone number")]
        public string CellPhone { get; set; }

        [StringLength(50, ErrorMessage = "Name must be less than 50 characters")]
        [RegularExpression("^[A-za-z0-9 #.-]*$", ErrorMessage = "Invalid")]
        public string CurrentEmployer { get; set; }
        [StringLength(50, ErrorMessage = "Name must be less than 50 characters")]
        [RegularExpression("^[A-za-z0-9 #.-]*$", ErrorMessage = "Invalid")]
        public string JobTitle { get; set; }
    }
}
