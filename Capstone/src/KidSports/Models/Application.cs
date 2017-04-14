using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models
{
    public class Application
    {
        public int ApplicationID { get; set; }
        public List<State> StatesLived { get; set; }
        public List<Country> CountriesLived { get; set; }
        public List<LastName> PreviousLastNames { get; set; }


        public string BackgroundRequest { get; set; }

        public string BackgroundResult { get; set; }
        public DateTime DOB { get; set; }

        public string CurrentEmployer { get; set; }
        public string JobTitle { get; set; }

        public string Address { get; set; }
        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public School AppSchool { get; set; }
        public Sport AppSport { get; set; }

        public Nullable<int> PreviousYearsCoached { get; set; }
        public Nullable<int> PreviousGradesCoached { get; set; }
        public string NameOfChild { get; set; }

        public int YearsExperience { get; set; }

        public DateTime AppStartDate { get; set; }
        public DateTime AppApprovalDate { get; set; }

        public bool AppIsChecked { get; set; }
        public DateTime BcSubmissionDate { get; set; }
        public DateTime BcApprovalDate { get; set; }
        public DateTime DlSubmissionDate { get; set; }
        public DateTime DlApprovalDate { get; set; }
        public string  DlPath { get; set; }

        public DateTime PcaSubmissionDate { get; set; }
        public DateTime PcaApprovalDate { get; set; }
        public bool PcaIsChecked { get; set; }
        public string PcaPath { get; set; }

        public string PcaVoucherCode { get; set; }

        public DateTime NfhsSubmissionDate { get; set; }
        public DateTime NfhsApprovalDate { get; set; }

        public bool NfhsIsChecked { get; set; }
        public string NfhsPath { get; set; }
        public DateTime BadgeSubmissionDate { get; set; }
        public DateTime BadgeApprovalDate { get; set; }
        public string BadgePath { get; set; }

        public DateTime PrefSubmissionDate { get; set; }
        public DateTime PrefApprovalDate { get; set; }

        public DateTime PledgeSubmissionDate { get; set; }
        public DateTime PledgeApprovalDate { get; set; }
        public string PledgeInitials { get; set; }

        public List<Area> Region { get; set; }












    }
}
