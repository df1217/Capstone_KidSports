using KidSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Repositories
{
    public class StateRepository : IStateRepo
    {
        private ApplicationDbContext context;

        public StateRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public List<State> GetAllStates()
        {

            //should work to order states alphabetically.
            return context.States.OrderBy(s => s.StateName).ToList();

        }

        public State GetStateByID(int ID)
        {
            return context.States.Where(x => x.StateID == ID).SingleOrDefault();
        }
    }
}
