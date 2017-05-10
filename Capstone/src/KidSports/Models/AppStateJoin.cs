using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models
{
    public class AppStateJoin
    {
        [Key]
        public int AppStateJoinID { get; set; }
        public int ApplicationID { get; set; }
        public int StateID { get; set; }
    }
}
