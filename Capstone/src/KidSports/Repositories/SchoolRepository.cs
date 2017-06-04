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

        public School GetSchoolByID(int id)
        {
            return context.Schools.Where(x => x.SchoolID == id).SingleOrDefault();
        }

        public School DeleteSchoolByID(int id)
        {
            var School = context.Schools.SingleOrDefault(s => s.id == id);
            return context.Schools.Remove(School);
            
        }

        public School AddSchool(string name)
        {
            School s = new School();
            s.name = name;
            return context.Schools.Add(s);

        }
    }
}
