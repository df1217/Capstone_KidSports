using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KidSports.Models;
using Microsoft.EntityFrameworkCore;

namespace KidSports.Repositories
{
    public class ApplicationRepository : IApplicationRepo
    {
        private ApplicationDbContext context;

        public ApplicationRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public List<Application> GetAllApplications()
        {
            return context.Applications.Include(a => a.State).Include(a => a.AppArea).Include(a => a.AppSchool).Include(a => a.AppSport).ToList();
        }

        public Application GetApplicationByID(int id)
        {
            return context.Applications.Where(x => x.ApplicationID == id).SingleOrDefault();
        }

        public List<AppStateJoin> GetStatesLivedIn(int id)
        {
            return context.StatesLived.Where(x => x.ApplicationID == id).ToList();
        }

        public void DeleteStatesLived(int id)
        {
            List<AppStateJoin> PastStates = context.StatesLived.Where(x => x.ApplicationID == id).ToList();
            foreach (var ps in PastStates)
            {
                context.StatesLived.Remove(ps);
                context.SaveChanges();
            }
        }

        public List<AppExpJoin> GetPastExperience(int id)
        {
            return context.PastExperiences.Where(x => x.ApplicationID == id).ToList();
        }

        public void DeletePastExperiences(int id)
        {
            List<AppExpJoin> PastExperiences = context.PastExperiences.Where(x => x.ApplicationID == id).ToList();
            foreach (var pe in PastExperiences)
            {
                context.PastExperiences.Remove(pe);
                context.SaveChanges();
            }
        }

        public IQueryable<Application> GetFilteredApplications(ApplicationSearchModel searchModel)
        {
            var result = context.Applications.AsQueryable();
            if (searchModel != null)
            {
                if (searchModel.Area.Count > 0)
                    result = result.Where(x => searchModel.Area.Exists(y => x.AppArea.AreaID == y));

                if (searchModel.School.Count > 0)
                    result = result.Where(x => searchModel.School.Exists(y => x.AppSchool.SchoolID == y));

                if (searchModel.Sport.Count > 0)
                    result = result.Where(x => searchModel.Sport.Exists(y => x.AppSport.SportID == y));

                //if (searchModel.Grade.Count > 0)
                //    result = result.Where(x => searchModel.Grade.Exists(y => x.AppArea == y)); 
            }
            return result;
        }

        public Application CreateApp(Application app)
        {
            context.Applications.Add(app);
            context.SaveChanges();
            return app;
        }

        public int Update(Application app)
        {
            if (app.ApplicationID == 0)
            {
                context.Applications.Add(app);
            }
            else
                context.Applications.Update(app);

            return context.SaveChanges();
        }

        public AppLink getAppLink(string Key)
        {
            return context.AppLinks.Where(al => al.Key == Key).SingleOrDefault();
        }

        public void UpdateAppLink(AppLink applink)
        {
            context.AppLinks.Update(applink);
            context.SaveChanges();
        }
    }
}