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
        private ISportRepo sportRepo;
        private IAreaRepo areaRepo;
        private ISchoolRepo schoolRepo;
        private IUserRepo userRepo;

        public AdminController(ISportRepo sportrepo, IAreaRepo arearepo, ISchoolRepo schoolrepo, IUserRepo userrepo)
        {
            schoolRepo = schoolrepo;
            sportRepo = sportrepo;
            areaRepo = arearepo;
            userRepo = userrepo;
        }

        #region UpdateAppContent
        [HttpGet]
        //public uacvm UpdateAppContentViewModel { get; private set; }
        public IActionResult UpdateAppContent()
        {
            UpdateAppContentViewModel uacvm = new UpdateAppContentViewModel();
            uacvm.AllSchools = schoolRepo.GetAllSchools();
            uacvm.AllAreas = areaRepo.GetAllAreas();
            uacvm.AllSports = sportRepo.GetAllSports();
            return View(uacvm);
        }

        [HttpPost]
        public IActionResult UACVMSchools(UpdateAppContentViewModel uacvm)
        {
            if (uacvm.Action == "delete")
                schoolRepo.DeleteSchoolByID(uacvm.deleteSchool);
            if (uacvm.Action == "add")
                schoolRepo.AddSchool(uacvm.addSchool);

            uacvm.AllSchools = schoolRepo.GetAllSchools();
            uacvm.AllAreas = areaRepo.GetAllAreas();
            uacvm.AllSports = sportRepo.GetAllSports();

            return View(uacvm);
        }

        public IActionResult UpdateAppLink()
        {
            return View();
        }

        public IActionResult UpdateUser()
        {
            UpdateUserViewModel uuvm = new UpdateUserViewModel();
            uuvm.allUsers = new List<User>();
            uuvm.allUsers = userRepo.GetAllUsers().ToList();
            return View(uuvm);
        }

        public IActionResult UpdateProfile()
        {
            return View();
        }
    }
}


#endregion