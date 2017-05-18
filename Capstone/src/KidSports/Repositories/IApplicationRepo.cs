using KidSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Repositories
{
    public interface IApplicationRepo
    {
        List<Application> GetAllApplications();
        IQueryable<Application> GetFilteredApplications(ApplicationSearchModel searchModel);
        Application GetApplicationByID(int id);
        int Update(Application app);
        Application CreateApp(Application app);
    }
}