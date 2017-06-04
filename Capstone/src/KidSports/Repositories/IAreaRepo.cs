using KidSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Repositories
{
    public interface IAreaRepo
    {
        List<Area> GetAllAreas();
        Area GetAreaByID(int id);
        Area AddArea(string name);
        void DeleteAreaByID(int ID);
    }
}
