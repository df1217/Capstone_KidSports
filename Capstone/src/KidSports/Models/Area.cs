using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models
{
    public class Area
    {
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public List<School> AreaSchools { get; set; }

    }
}
