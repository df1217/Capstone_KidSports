using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KidSports.Models;

namespace KidSports.Repositories
{
    public class AppStatusRepository : IAppStatusRepo
    {
        private ApplicationDbContext context;

        public AppStatusRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public ApplicationStatus GetAppStatusByID(int AppID)
        {
            return context.ApplicationStatus.Where(x => x.ApplicationID == AppID).SingleOrDefault();
        }

        public ApplicationStatus Create(ApplicationStatus appStatus)
        {
            context.ApplicationStatus.Add(appStatus);
            context.SaveChanges();
            return appStatus;
        }

        public int Update(ApplicationStatus appStatus)
        {
            if (appStatus.ApplicationStatusID == 0)
            {
                context.ApplicationStatus.Add(appStatus);
            }
            else
                context.ApplicationStatus.Update(appStatus);

            return context.SaveChanges();
        }
    }
}
