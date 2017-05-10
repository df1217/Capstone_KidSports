using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models
{
    public class AppAreaJoin
    {
        [Key]
        public int AppAreaJoinID { get; set; }
        public int ApplicationID { get; set; }
        public int AreaID { get; set; }
    }
}
