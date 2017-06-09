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
        List<AppStateJoin> GetStatesLivedIn(int id);
        List<AppExpJoin> GetPastExperience(int id);
        void DeletePastExperiences(int id);
        void DeleteStatesLived(int id);
        AppLink getAppLink(string Key);
        void UpdateAppLink(AppLink applink);
    }
}