using KidSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Repositories
{
    public interface ISchoolRepo
    {
        List<School> GetAllSchools();
        List<School> GetSchoolsByArea(Area area);
        List<School> GetSchoolBySM(User user);
        School GetSchoolByID(int id);
    }
}
