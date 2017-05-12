using KidSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Repositories
{
    public class AreaRepository : IAreaRepo
    {
        private ApplicationDbContext context;

        public AreaRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public List<Area> GetAllAreas()
        {
            return context.Areas.ToList();
        }
    }
}
