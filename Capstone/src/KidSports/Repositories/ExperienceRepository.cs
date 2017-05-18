using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KidSports.Models;

namespace KidSports.Repositories
{
    public class ExperienceRepository : IExpRepo
    {
        private ApplicationDbContext context;

        public ExperienceRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public List<Experience> GetAllExperiences()
        {
            return context.Experiences.ToList();
        }

        public Experience GetExperienceByID(int id)
        {
            return context.Experiences.Where(x => x.ExperienceID == id).SingleOrDefault();
        }
    }
}
