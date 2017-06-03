using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KidSports.Models;

namespace KidSports.Repositories
{
    public class SportRepository : ISportRepo
    {
        private ApplicationDbContext context;

        public SportRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public List<Sport> GetAllSports()
        {
            return context.Sports.ToList();
        }

        public Sport GetSportsByID(int id)
        {
            return context.Sports.Where(x => x.SportID == id).SingleOrDefault();
        }

        public Sport GetSportsByName(string name)
        {
            return context.Sports.Where(x => x.SportName == name).SingleOrDefault();
        }

        public Sport DeleteSportByID(int id)
        {
            var Sport = context.Sports.SingleOrDefault(s => s.id == id);
            return context.Sports.Remove(Sport);

        }

        public Sport AddSport(string name)
        {
            Sport s = new Sport();
            s.name = name;
            return context.Sports.Add(s);

        }
    }
}
