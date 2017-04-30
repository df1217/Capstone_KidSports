using KidSports.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace KidSports.Models.ViewModels
{
    public class ConcussionCourseViewModel
    {
        public int ApplicationID { get; set; }
        public DateTime ConcussionCourseDate { get; set; }
        public IFormFile File { get; set; }
        public Nullable<bool> IsApproved { get; set; }

    }
}
