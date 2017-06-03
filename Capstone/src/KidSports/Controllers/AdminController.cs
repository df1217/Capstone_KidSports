using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using KidSports.Models.ViewModels;
using KidSports.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using KidSports.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace KidSports.Controllers
{

    public class AdminController : Controller
    {
        private IHostingEnvironment _environment;
        private ISportRepo sportRepo;
        private IAreaRepo areaRepo;
        private ISchoolRepo schoolRepo;

        public AdminController(IHostingEnvironment environment, ISportRepo sportrepo, IAreaRepo arearepo, ISchoolRepo schoolrepo)
        {
            schoolRepo = schoolrepo;
            sportRepo = sportrepo;
            areaRepo = arearepo;

        }
        #region UpdateAppContent
        [HttpGet]
        //public uacvm UpdateAppContentViewModel { get; private set; }
        public IActionResult UpdateAppContent()

        {
            UpdateAppContentViewModel uacvm = new UpdateAppContentViewModel;
            uacvm.AllSchools = schoolRepo.GetAllSchools();
            uacvm.AllAreas = areaRepo.GetAllSAreas();
            uacvm.AllSports = schoolRepo.GetAllSports();
        }
        [HttpPost]
        public async Task<IActionResult> UACVMSchools(UpdateAppContentViewModel uacvm)
        {
            if (uacvm.Action == "delete")
                schoolRepo.DeleteByID(UpdateAppContentViewModel.deleteSport);
            if (uacvm.Action == "add")
                schoolRepo.AddSchool(UpdateAppContentViewModel.addSport);

            uacvm.AllSchools = schoolRepo.GetAllSchools();
            uacvm.AllAreas = areaRepo.GetAllSAreas();
            uacvm.AllSports = schoolRepo.GetAllSports();

            return View(uacvm);
        }

        public IActionResult UpdateAppLink()
        {
            return View();
        }

        public IActionResult UpdateUser()
        {
            return View();
        }

        public IActionResult UpdateProfile()
        {
            return View();
        }
    }
}


#endregion