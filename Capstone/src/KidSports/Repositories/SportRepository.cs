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

        public void DeleteSportByID(int id)
        {
            var Sport = context.Sports.SingleOrDefault(s => s.SportID == id);
            context.Sports.Remove(Sport);
            context.SaveChanges();
        }

        public Sport AddSport(string name)
        {
            Sport s = new Sport();
            s.SportName = name;
            context.Sports.Add(s);
            context.SaveChanges();
            return s;
        }
    }
}
