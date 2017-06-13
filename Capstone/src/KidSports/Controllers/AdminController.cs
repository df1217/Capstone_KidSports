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
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IUserRepo userRepo;
        private IApplicationRepo appRepo;
        private ISportRepo sportRepo;
        private IAreaRepo areaRepo;
        private ISchoolRepo schoolRepo;
        private UserManager<User> uM;

        public AdminController(IUserRepo userrepo, IApplicationRepo apprepo, UserManager<User> um, ISportRepo sportrepo, IAreaRepo arearepo, ISchoolRepo schoolrepo)
        {
            userRepo = userrepo;
            appRepo = apprepo;
            uM = um;
            sportRepo = sportrepo;
            areaRepo = arearepo;
            schoolRepo = schoolrepo;
        }

        [HttpGet]
        public IActionResult UpdateAppLink()
        {
            UpdateAppLinkViewModel applinks = new UpdateAppLinkViewModel();

            applinks.pledge = appRepo.getAppLink("Pledge").Link;
            applinks.nfhs = appRepo.getAppLink("NFHS").Link;
            applinks.pca = appRepo.getAppLink("PCA").Link;
            applinks.voucher = appRepo.getAppLink("Voucher").Link;

            return View(applinks);
        }

        [HttpPost]
        public IActionResult UpdateAppLink(UpdateAppLinkViewModel applinks)
        {
            AppLink pledge = new AppLink();
            pledge = appRepo.getAppLink("Pledge");
            pledge.Link = applinks.pledge;
            appRepo.UpdateAppLink(pledge);

            AppLink nfhs = new AppLink();
            nfhs = appRepo.getAppLink("NFHS");
            nfhs.Link = applinks.nfhs;
            appRepo.UpdateAppLink(nfhs);

            AppLink pca = new AppLink();
            pca = appRepo.getAppLink("PCA");
            pca.Link = applinks.pca;
            appRepo.UpdateAppLink(pca);

            AppLink voucher = new AppLink();
            voucher = appRepo.getAppLink("Voucher");
            voucher.Link = applinks.voucher;
            appRepo.UpdateAppLink(voucher);

            return View(applinks);
        }

        [HttpGet]
        public IActionResult UpdateAppContent()
        {
            UpdateAppContentViewModel appcontent = new UpdateAppContentViewModel();
            appcontent.allAreas = new List<Area>();
            appcontent.allSchools = new List<School>();
            appcontent.allSports = new List<Sport>();

            appcontent.allAreas = areaRepo.GetAllAreas();
            appcontent.allSchools = schoolRepo.GetAllSchools();
            appcontent.allSports = sportRepo.GetAllSports();

            return View(appcontent);
        }

        [HttpPost]
        public IActionResult addArea(UpdateAppContentViewModel uacvm)
        {
            uacvm.allAreas = new List<Area>();
            uacvm.allSchools = new List<School>();
            uacvm.allSports = new List<Sport>();

            areaRepo.AddArea(uacvm.area);
            uacvm.area = "";

            uacvm.allAreas = areaRepo.GetAllAreas();
            uacvm.allSchools = schoolRepo.GetAllSchools();
            uacvm.allSports = sportRepo.GetAllSports();

            return View("UpdateAppContent", uacvm);
        }

        [HttpPost]
        public IActionResult deleteArea(UpdateAppContentViewModel uacvm)
        {
            uacvm.allAreas = new List<Area>();
            uacvm.allSchools = new List<School>();
            uacvm.allSports = new List<Sport>();

            areaRepo.DeleteAreaByID(uacvm.deletearea);
            uacvm.deletearea = -1;

            uacvm.allAreas = areaRepo.GetAllAreas();
            uacvm.allSchools = schoolRepo.GetAllSchools();
            uacvm.allSports = sportRepo.GetAllSports();

            return View("UpdateAppContent", uacvm);
        }


        [HttpPost]
        public IActionResult addSchool(UpdateAppContentViewModel uacvm)
        {
            uacvm.allAreas = new List<Area>();
            uacvm.allSchools = new List<School>();
            uacvm.allSports = new List<Sport>();

            schoolRepo.AddSchool(uacvm.school);
            uacvm.school = "";

            uacvm.allAreas = areaRepo.GetAllAreas();
            uacvm.allSchools = schoolRepo.GetAllSchools();
            uacvm.allSports = sportRepo.GetAllSports();

            return View("UpdateAppContent", uacvm);
        }

        [HttpPost]
        public IActionResult deleteSchool(UpdateAppContentViewModel uacvm)
        {
            uacvm.allAreas = new List<Area>();
            uacvm.allSchools = new List<School>();
            uacvm.allSports = new List<Sport>();

            schoolRepo.DeleteSchoolByID(uacvm.deleteschool);
            uacvm.deleteschool = -1;

            uacvm.allAreas = areaRepo.GetAllAreas();
            uacvm.allSchools = schoolRepo.GetAllSchools();
            uacvm.allSports = sportRepo.GetAllSports();

            return View("UpdateAppContent", uacvm);
        }

        [HttpPost]
        public IActionResult addSport(UpdateAppContentViewModel uacvm)
        {
            uacvm.allAreas = new List<Area>();
            uacvm.allSchools = new List<School>();
            uacvm.allSports = new List<Sport>();

            sportRepo.AddSport(uacvm.sport);
            uacvm.sport = "";

            uacvm.allAreas = areaRepo.GetAllAreas();
            uacvm.allSchools = schoolRepo.GetAllSchools();
            uacvm.allSports = sportRepo.GetAllSports();

            return View("UpdateAppContent", uacvm);
        }

        [HttpPost]
        public IActionResult deleteSport(UpdateAppContentViewModel uacvm)
        {
            uacvm.allAreas = new List<Area>();
            uacvm.allSchools = new List<School>();
            uacvm.allSports = new List<Sport>();

            sportRepo.DeleteSportByID(uacvm.deletesport);
            uacvm.deletesport = -1;

            uacvm.allAreas = areaRepo.GetAllAreas();
            uacvm.allSchools = schoolRepo.GetAllSchools();
            uacvm.allSports = sportRepo.GetAllSports();

            return View("UpdateAppContent", uacvm);
        }

        [HttpGet]
        public IActionResult UpdateUser()
        {
            UpdateUserViewModel uuvm = new UpdateUserViewModel();
            uuvm.allUsers = new List<User>();
            uuvm.allRoles = new List<string>();
            uuvm.allUsers = userRepo.GetAllUsers().ToList();

            foreach (User u in uuvm.allUsers)
                uuvm.allRoles.Add(userRepo.GetRoleNameByIdentityID(u.Id));

            return View(uuvm);
        }


        [HttpPost]
        public IActionResult UpdateUser(UpdateUserViewModel uuvm)
        {
            IEnumerable<string> roles = new List<string>() { "Applicant", "SportsManager", "Admin"};
            
            User u = userRepo.GetUserByIdentityID(uuvm.userToUpdate);

            if (uuvm.FirstName != null && uuvm.FirstName != "" && uuvm.FirstName != u.FirstName)
                u.FirstName = uuvm.FirstName;

            if (uuvm.MiddleName != null && uuvm.MiddleName != "" && uuvm.MiddleName != u.MiddleName)
                u.MiddleName = uuvm.MiddleName;

            if (uuvm.LastName != null && uuvm.LastName != "" && uuvm.LastName != u.LastName)
                u.LastName = uuvm.LastName;

            if (uuvm.Email != null && uuvm.Email != "" && uuvm.Email != u.Email)
                u.Email = uuvm.Email;

            if (uuvm.Role != null && uuvm.Role != "")
            {
                userRepo.DeleteUserRoles(u.Id);
                var asyncTaskResult = uM.AddToRoleAsync(u, uuvm.Role);
                asyncTaskResult.Wait();
            }

            uuvm.allUsers = new List<User>();
            uuvm.allRoles = new List<string>();
            uuvm.allUsers = userRepo.GetAllUsers().ToList();

            foreach (User user in uuvm.allUsers)
                uuvm.allRoles.Add(userRepo.GetRoleNameByIdentityID(user.Id));

            return View(uuvm);
        }

        [HttpPost]
        public IActionResult AddUser(UpdateUserViewModel uuvm)
        {
            IdentityResult result;
            var role = UserRole.Applicant;

            if (uuvm.Role == "Admin")
                role = UserRole.Admin;
            else if (uuvm.Role == "SportsManager")
                role = UserRole.SportsManager;

            if (uuvm.FirstName != null && uuvm.MiddleName != null && uuvm.LastName != null && uuvm.Email != null)
                userRepo.AdminCreateUser(uuvm.FirstName, uuvm.MiddleName, uuvm.LastName, uuvm.Email, role, out result);

            uuvm.allUsers = new List<User>();
            uuvm.allRoles = new List<string>();
            uuvm.allUsers = userRepo.GetAllUsers().ToList();

            foreach (User u in uuvm.allUsers)
                uuvm.allRoles.Add(userRepo.GetRoleNameByIdentityID(u.Id));

            uuvm.FirstName = "";
            uuvm.MiddleName = "";
            uuvm.LastName = "";
            uuvm.Email = "";
            uuvm.Role = "";

            return View("UpdateUser", uuvm);
        }

        [HttpPost]
        public IActionResult DeleteUser(UpdateUserViewModel uuvm)
        {
            if (uuvm.userToDelete != null)
                userRepo.DeleteUserByID(uuvm.userToDelete);

            uuvm.allUsers = new List<User>();
            uuvm.allRoles = new List<string>();
            uuvm.allUsers = userRepo.GetAllUsers().ToList();

            foreach (User u in uuvm.allUsers)
                uuvm.allRoles.Add(userRepo.GetRoleNameByIdentityID(u.Id));

            return View("UpdateUser", uuvm);
        }
    }
}
