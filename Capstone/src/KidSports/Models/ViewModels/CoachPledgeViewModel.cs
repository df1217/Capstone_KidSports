using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models.ViewModels
{
    public class CoachPledgeViewModel
    {
        public string Direction { get; set; }

        public int ApplicationID { get; set; }
        [Required(ErrorMessage = "Must click link to view Pledge.")]
        public bool IsInAgreement { get; set; }

        public ApplicationStatus ApplicationStatus { get; set; }
        [RegularExpression("^([A-Z]{1}[a-zA-Z ]*$)", ErrorMessage = "Name must be capitalized and not contain any digits or special characters")]
        public string Name { get; set; }
        [StringLength(5, ErrorMessage = "Initials must be less than 6 characters ")]
        [RegularExpression("[a-zA-Z]*$", ErrorMessage = "Initials must not contain any spaces digits or special characters")]
        public string Initials { get; set; }
        public DateTime? PledgeSubmissionDate { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public AppLink pledgeLink { get; set; }

    }
}
