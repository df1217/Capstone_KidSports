using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models
{
    public class AppSportJoin
    {
        [Key]
        public int AppSportJoinID { get; set; }
        public int ApplicationID { get; set; }
        public int SportID { get; set; }
    }
}