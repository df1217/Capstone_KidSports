using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Models.ViewModels
{
    public class UpdateAppContentViewModel
    {
        public List<Area> allAreas { get; set; }
        public List<School> allSchools { get; set; }
        public List<Sport> allSports { get; set; }

        public string area { get; set; }
        public string school { get; set; }
        public string sport { get; set; }

        public int deletearea { get; set; }
        public int deleteschool { get; set; }
        public int deletesport { get; set; }
    }
}
