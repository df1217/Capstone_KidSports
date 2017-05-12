using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KidSports.Models;

namespace KidSports.Repositories
{
    public class SchoolRepository : ISchoolRepo
    {
        private ApplicationDbContext context;

        public SchoolRepository(ApplicationDbContext ctx)
        { 
            context = ctx;
        }

        public List<School> GetAllSchools()
        {
            return context.Schools.ToList();
        }

        public List<School> GetSchoolBySM(User user)
        {
            throw new NotImplementedException();
        }

        public List<School> GetSchoolsByArea(Area area)
        {
            return context.Schools.Where(x => area.AreaSchools.Contains(x)).ToList();
        }
    }
}
