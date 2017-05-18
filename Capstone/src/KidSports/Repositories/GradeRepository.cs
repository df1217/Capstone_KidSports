using KidSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Repositories
{
    public class GradeRepository : IGradeRepo
    {
        public ApplicationDbContext context;
        public GradeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public List<Grade> GetAllGrades()
        {
            return context.Grades.ToList();
        }
    }
}
