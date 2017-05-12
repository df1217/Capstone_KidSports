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
            return context.States.ToList();
        }
    }
}
