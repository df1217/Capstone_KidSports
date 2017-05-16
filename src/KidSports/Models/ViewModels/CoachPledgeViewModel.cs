using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models.ViewModels
{
    public class CoachPledgeViewModel
    {
        public string Direction { get; set; }
        public int ApplicationID { get; set; }

        public ApplicationStatus ApplicationStatus { get; set; }
        public string Name { get; set; }
        public string  Initials { get; set; }
        public  DateTime PledgeSubmissionDate { get; set; }
        public Nullable<bool> IsApproved { get; set; }

    }
}
