using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models.ViewModels
{
    public class ApplicantDetailsViewModel
    {
        public User applicant { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public int appID { get; set; }
        public string PageName { get; set; }


        public string getCoachInfoClass()
        {
            if (this.ApplicationStatus.CoachInfoApprovalDate != null && this.ApplicationStatus.CoachInfoApprovalDate != new DateTime())
                return "waveShape-Approved";
            else if (this.ApplicationStatus.CoachInfoSubmissionDate != null && this.ApplicationStatus.CoachInfoSubmissionDate != new DateTime())
                return "waveShape-Complete";
            else
                return "waveShape-Incomplete";
        }

        public string getCoachInterestClass()
        {
            if (this.ApplicationStatus.CoachInterestApprovalDate != null && this.ApplicationStatus.CoachInterestApprovalDate != new DateTime())
                return "waveShape-Approved";
            else if (this.ApplicationStatus.CoachInterestSubmissionDate != null && this.ApplicationStatus.CoachInterestSubmissionDate != new DateTime())
                return "waveShape-Complete";
            else
                return "waveShape-Incomplete";
        }


        public string getCoachPledgeClass()
        {
            if (this.ApplicationStatus.PledgeApprovalDate != null && this.ApplicationStatus.PledgeApprovalDate != new DateTime())
                return "waveShape-Approved";
            else if (this.ApplicationStatus.PledgeSubmissionDate != null && this.ApplicationStatus.PledgeSubmissionDate != new DateTime())
                return "waveShape-Complete";
            else
                return "waveShape-Incomplete";
        }

        public string getCoachNFHSClass()
        {
            if (this.ApplicationStatus.NFHSApprovalDate != null && this.ApplicationStatus.NFHSApprovalDate != new DateTime())
                return "waveShape-Approved";
            else if (this.ApplicationStatus.NFHSSubmissionDate != null && this.ApplicationStatus.NFHSSubmissionDate != new DateTime())
                return "waveShape-Complete";
            else
                return "waveShape-Incomplete";
        }

        public string getCoachPcaClass()
        {
            if (this.ApplicationStatus.PcaApprovalDate != null && this.ApplicationStatus.PcaApprovalDate != new DateTime())
                return "waveShape-Approved";
            else if (this.ApplicationStatus.PcaSubmissionDate != null && this.ApplicationStatus.PcaSubmissionDate != new DateTime())
                return "waveShape-Complete";
            else
                return "waveShape-Incomplete";
        }


        public string getCoachIDClass()
        {
            if (this.ApplicationStatus.IdApprovalDate != null && this.ApplicationStatus.IdApprovalDate != new DateTime())
                return "waveShape-Approved";
            else if (this.ApplicationStatus.IdSubmissionDate != null && this.ApplicationStatus.IdSubmissionDate != new DateTime())
                return "waveShape-Complete";
            else
                return "waveShape-Incomplete";
        }

        public string getCoachBadgeClass()
        {
            if (this.ApplicationStatus.BadgeApprovalDate != null && this.ApplicationStatus.BadgeApprovalDate != new DateTime())
                return "waveShape-Approved";
            else if (this.ApplicationStatus.BadgeSubmissionDate != null && this.ApplicationStatus.BadgeSubmissionDate != new DateTime())
                return "waveShape-Complete";
            else
                return "waveShape-Incomplete";
        }
    }
}
