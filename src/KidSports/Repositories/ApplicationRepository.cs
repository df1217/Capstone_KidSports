using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KidSports.Models;

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
            return context.Applications.ToList();
        }

        public Application GetApplicationByID(int id)
        {
            return context.Applications.Where(x => x.ApplicationID == id).SingleOrDefault();
        }

        public IQueryable<Application> GetFilteredApplications(ApplicantSearchModel searchModel)
        {
            var result = context.Applications.AsQueryable();
            if (searchModel != null)
            {
                if (!string.IsNullOrEmpty(searchModel.Area))
                    result = result.Where(x => x.AppArea.AreaName == searchModel.Area);

                if (!string.IsNullOrEmpty(searchModel.School))
                    result = result.Where(x => x.AppSchool.SchoolName == searchModel.School);

                if (!string.IsNullOrEmpty(searchModel.Sport))
                    result = result.Where(x => x.AppSport.SportName == searchModel.Sport);

                if (!string.IsNullOrEmpty(searchModel.Gender))
                    result = result.Where(x => x.AppGender == searchModel.Gender);

                if (!string.IsNullOrEmpty(searchModel.Grade))
                    result = result.Where(x => x.AppGrade == searchModel.Grade);
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
    }
}