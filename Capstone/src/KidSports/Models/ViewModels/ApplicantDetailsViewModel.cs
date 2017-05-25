using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models.ViewModels
{
    public class ApplicantDetailsViewModel
    {
        public User applicant { get; set; }
        public ApplicationStatus appstatus { get; set; }
    }
}
