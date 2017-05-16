using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models
{
    public class Sport
    {
        public int SportID { get; set; }
        public string Gender { get; set; }
        public int MinGrade { get; set; }
        public int MaxGrade { get; set; }
        public string SportName { get; set; }
    }
}
