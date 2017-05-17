using KidSports.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace KidSports.Models.ViewModels
{
    public class PcaCourseViewModel
    {
        public int ApplicationID { get; set; }
        public string Direction { get; set; }

        public ApplicationStatus ApplicationStatus { get; set; }
        public DateTime PcaCourseSubmissionDate { get; set; }
        public IFormFile File { get; set; }
        public Nullable<bool> IsApproved { get; set; }
    }
}
