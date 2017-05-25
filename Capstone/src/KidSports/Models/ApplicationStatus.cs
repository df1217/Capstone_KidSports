using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models
{
    public class ApplicationStatus
    {
        public int ApplicationStatusID { get; set; }
        public int ApplicationID { get; set; }
        public DateTime AppStartDate { get; set; }

        public DateTime? AppApprovalDate { get; set; }
        public DateTime? AppCompletionDate { get; set; }

        public DateTime? AppDenialDate { get; set; }
        public DateTime? BcStartDate { get; set; }
        public DateTime? BcSubmissionDate { get; set; }
        public DateTime? BcApprovalDate { get; set; }
        public DateTime? PrefSubmissionDate { get; set; }
        public DateTime? PrefApprovalDate { get; set; }
        public DateTime? PrefDenialDate { get; set; }

    }
}
