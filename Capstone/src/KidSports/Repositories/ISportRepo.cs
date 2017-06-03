using KidSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Repositories
{
    public interface ISportRepo
    {
        List<Sport> GetAllSports();
        Sport GetSportsByName(string name);
        Sport GetSportsByID(int id);
        Sport AddSport(string name);
        Sport DeleteSportByID(int ID);
    }
}
