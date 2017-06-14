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

        public Area GetAreaByID(int id)
        {
            return context.Areas.Where(x => x.AreaID == id).SingleOrDefault();
        }

        public void DeleteAreaByID(int id)
        {
            var Area = context.Areas.SingleOrDefault(s => s.AreaID == id);
            context.Areas.Remove(Area);
            context.SaveChanges();
        }

        public Area AddArea(string name)
        {
            Area a = new Area();
            a.AreaName = name;
            context.Areas.Add(a);
            context.SaveChanges();
            return a;
        }
    }
}
