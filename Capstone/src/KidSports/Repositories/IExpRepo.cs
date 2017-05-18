using KidSports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidSports.Repositories
{
    public interface IExpRepo
    {
        List<Experience> GetAllExperiences();
        Experience GetExperienceByID(int id);
    }
}
