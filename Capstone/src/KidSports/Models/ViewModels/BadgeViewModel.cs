using KidSports.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace KidSports.Models.ViewModels
{
    public class BadgeViewModel
    {
        public string Direction { get; set; }
        public int ApplicationID { get; set; }
        public IFormFile File { get; set; }
        public string BadgePath { get; set; }
        public Nullable<bool> IsApproved { get; set; }
    }
}
