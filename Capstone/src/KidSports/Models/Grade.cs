using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models
{
    public class Grade
    {
        //Do we want to remove this? and use strings? I dont see a list anywhere so this may not be necessary.
        public int GradeID { get; set; }
        public string GradeName { get; set; }
    }
}
