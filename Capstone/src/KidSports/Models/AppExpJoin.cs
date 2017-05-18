using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models
{
    public class AppExpJoin
    {
        [Key]
        public int AppExpJoinID { get; set; }
        public int ApplicationID { get; set; }
        public int ExperienceID { get; set; }
    }
}
