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
        [RegularExpression("true", ErrorMessage = "Must click on the Coach Pledge link")]
        public string HasClicked { get; set; }
        public int ApplicationID { get; set; }

        public bool IsInAgreement { get; set; }

        public ApplicationStatus ApplicationStatus { get; set; }
        public string Name { get; set; }
        public string  Initials { get; set; }
        public  DateTime PledgeSubmissionDate { get; set; }
        public Nullable<bool> IsApproved { get; set; }

    }
}
