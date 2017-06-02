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

        public DateTime? CoachInfoSubmissionDate { get; set; }
        public DateTime? CoachInfoApprovalDate { get; set; }
        public DateTime? CoachInfoDenialDate { get; set; }

        public DateTime? CoachInterestSubmissionDate { get; set; }
        public DateTime? CoachInterestApprovalDate { get; set; }
        public DateTime? CoachInterestDenialDate { get; set; }

        public DateTime? PledgeSubmissionDate { get; set; }
        public DateTime? PledgeApprovalDate { get; set; }
        public DateTime? PledgeDenialDate { get; set; }

        public DateTime? NFHSSubmissionDate { get; set; }
        public DateTime? NFHSApprovalDate { get; set; }
        public DateTime? NFHSDenialDate { get; set; }

        public DateTime? PcaSubmissionDate { get; set; }
        public DateTime? PcaApprovalDate { get; set; }
        public DateTime? PcaDenialDate { get; set; }

        public DateTime? IdSubmissionDate { get; set; }
        public DateTime? IdApprovalDate { get; set; }
        public DateTime? IdDenialDate { get; set; }

        public DateTime? BadgeSubmissionDate { get; set; }
        public DateTime? BadgeApprovalDate { get; set; }
        public DateTime? BadgeDenialDate { get; set; }

    }
}
