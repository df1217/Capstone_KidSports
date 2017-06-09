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
        private IUserRepo userRepo;
        private IApplicationRepo appRepo;

        public AdminController(IUserRepo userrepo, IApplicationRepo apprepo)
        {
            userRepo = userrepo;
            appRepo = apprepo;
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
    }
}
