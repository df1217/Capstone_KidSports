using KidSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Repositories
{
    public interface IAppStatusRepo
    {
        ApplicationStatus GetAppStatusByID(int AppID);
        ApplicationStatus Create(ApplicationStatus appStatus);
        int Update(ApplicationStatus appStatus);
    }
}
