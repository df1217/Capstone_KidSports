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

namespace KidSports.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        private IHostingEnvironment _environment;
        private IApplicationRepo appRepo;
        private IUserRepo userRepo;
        UserManager<User> userManager;

        public ApplicationController(UserManager<User> UM, IHostingEnvironment environment, IApplicationRepo apprepo, IUserRepo userrepo)
        {
            userManager = UM;
            _environment = environment;
            appRepo = apprepo;
            userRepo = userrepo;
        }

        #region Home Page
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IndexViewModel ivm = new IndexViewModel();
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                user = userRepo.GetDetailedUser(user);
                if (user.currentYearApp != null)
                {
                    int id = user.currentYearApp.ApplicationID;
                    ivm.ApplicationID = id;
                    return View(ivm);
                }
            }

            ivm.ApplicationID = 0;
            return View(ivm);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IndexViewModel ivm)
        {

            if (ivm.ApplicationID != 0)
            {
                /* Use app id to do stuff */
                if (ivm.PageName == "CoachInfo") 
                    return RedirectToAction("CoachInfo", ivm.ApplicationID);
                if (ivm.PageName == "CoachInterests")
                    return RedirectToAction("CoachInterests", ivm.ApplicationID);
                if (ivm.PageName == "CoachPledge")
                    return RedirectToAction("CoachPledge", ivm.ApplicationID);
                if (ivm.PageName == "ConcussionCourse")
                    return RedirectToAction("ConcussionCourse", new { AppID = ivm.ApplicationID });
                if (ivm.PageName == "PcaCourse")
                    return RedirectToAction("PcaCourse", ivm.ApplicationID);
                if (ivm.PageName == "ID")
                    return RedirectToAction("ID", ivm.ApplicationID);
                if (ivm.PageName == "Badge")
                    return RedirectToAction("Badge", ivm.ApplicationID);
                return View(ivm);
            }
            else
            {
                Application app = new Application();
                appRepo.CreateApp(app);
                ivm.ApplicationID = app.ApplicationID;
                User user = await userManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                {
                    user.currentYearApp = app;
                    userRepo.Update(user);
                }
                return RedirectToAction("CoachInfo", ivm.ApplicationID);
            }
        }

        #endregion

        #region SportsManager Views
        [HttpGet]
        [Authorize(Roles = "SportsManager")]
        public IActionResult Applications()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "SportsManager")]
        public IActionResult ApplicantDetails()
        {
            return View();
        }
        #endregion

        #region Background Check
        [HttpGet]
        //List all background checks that have been processed by the CRIS API and are awaiting approval.
        public IActionResult BackgroundCheckResults()
        {
            return View();
        }

        //Display the result incidents of the specific background check.
        [HttpGet]
        public IActionResult BGCResultsDescription()
        {
            return View();
        }
        #endregion

        #region Application Coach Information
        [HttpGet]
        public IActionResult CoachInfo(int AppID)
        {
            //Get the coaches current app
            Application currentApp = appRepo.GetApplicationByID(AppID);
            CoachInfoViewModel civm = new CoachInfoViewModel();
            //If any information exists, bind it to the view model.

            //Display the view.
            return View(civm);
        }

        [HttpPost]
        public IActionResult CoachInfo(CoachInfoViewModel civm)
        {
            //Process all data that is in the view model. If anything is new or changed,
            //update the coaches current application.


            //Decide which direction is being taken (this page only has next).
            if (civm.Direction == "next")
                return RedirectToAction("CoachInterests", civm.ApplicationID);

            //if all else fails, post back to the same page.
            return View(civm);
        }
        #endregion

        #region Application Coach Interests
        [HttpGet]
        public IActionResult CoachInterests(int AppID)
        {
            //Get the coaches current app
            Application currentApp = appRepo.GetApplicationByID(AppID);
            CoachInterestViewModel civm = new CoachInterestViewModel();
            //If any information exists, bind it to the view model.

            //Display the view.
            return View(civm);
        }

        [HttpPost]
        public IActionResult CoachInterests(CoachInterestViewModel civm)
        {
            //Process all data that is in the view model. If anything is new or changed,
            //update the coaches current application.


            //Decide which direction is being taken.
            if (civm.Direction == "previous")
                return RedirectToAction("CoachInfo", civm.ApplicationID);
            if (civm.Direction == "next")
                return RedirectToAction("CoachPledge", civm.ApplicationID);

            //if all else fails, post back to the same page.
            return View(civm);
        }
        #endregion

        #region Application Coach Pledge
        [HttpGet]
        public IActionResult CoachPledge(int AppID)
        {
            //Get the coaches current app
            Application currentApp = appRepo.GetApplicationByID(AppID);
            CoachPledgeViewModel cpvm = new CoachPledgeViewModel();
            //If any information exists, bind it to the view model.

            //Display the view.
            return View(cpvm);
        }

        [HttpPost]
        public IActionResult CoachPledge(CoachPledgeViewModel cpvm)
        {
            //Process all data that is in the view model. If anything is new or changed,
            //update the coaches current application.


            //Decide which direction is being taken.
            if (cpvm.Direction == "previous")
                return RedirectToAction("CoachInterests", cpvm.ApplicationID);
            if (cpvm.Direction == "next")
                return RedirectToAction("ConcussionCourse", cpvm.ApplicationID);

            //if all else fails, post back to the same page.
            return View(cpvm);
        }
        #endregion

        #region Application Concussion Course
        [HttpGet]
        public IActionResult ConcussionCourse(int AppID)
        {
            //Get the coaches current app
            Application currentApp = appRepo.GetApplicationByID(AppID);
            ConcussionCourseViewModel ccvm = new ConcussionCourseViewModel();
            ccvm.ApplicationID = AppID;
            //If any information exists, bind it to the view model.

            //Display the view.
            return View(ccvm);
        }

        [HttpPost]
        public async Task<IActionResult> ConcussionCourse(ConcussionCourseViewModel ccvm)
        {
            //Process all data that is in the view model. If anything is new or changed,
            //update the coaches current application.
            Application currentApp = appRepo.GetApplicationByID(ccvm.ApplicationID);

            if (ccvm.File != null)
            {
                var uploads = Path.Combine(_environment.WebRootPath, "Images", "ConcussionCourse");
                if (ccvm.File.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, ccvm.ApplicationID.ToString() + ".jpg"), FileMode.Create))
                    {
                        await ccvm.File.CopyToAsync(fileStream);
                        currentApp.NfhsPath = fileStream.Name.ToString();
                    }
                }
                appRepo.Update(currentApp);
            }

           


            //Decide which direction is being taken.
            if (ccvm.Direction == "previous")
                return RedirectToAction("CoachPledge", ccvm.ApplicationID);
            if (ccvm.Direction == "next")
            {
                if (currentApp.IsHeadCoach == true)
                    return RedirectToAction("PcaCourse", ccvm.ApplicationID);
                else
                    return RedirectToAction("ID", ccvm.ApplicationID);
            }

            //if all else fails, post back to the same page.
            return View(ccvm);
        }
        #endregion

        #region Application Pca Course
        [HttpGet]
        public IActionResult PcaCourse(int AppID)
        {
            //Get the coaches current app
            Application currentApp = appRepo.GetApplicationByID(AppID);
            PcaCourseViewModel pcvm = new PcaCourseViewModel();
            //If any information exists, bind it to the view model.

            //Display the view.
            return View(pcvm);
        }

        [HttpPost]
        public async Task<IActionResult> PcaCourse(PcaCourseViewModel pcvm)
        {
            //Process all data that is in the view model. If anything is new or changed,
            //update the coaches current application.
            var uploads = Path.Combine(_environment.WebRootPath);
            if (pcvm.File.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, pcvm.File.FileName), FileMode.Create))
                {
                    await pcvm.File.CopyToAsync(fileStream);
                }
                //p5Vm.Application.PcaPath = $"\\{p5Vm.File.FileName}";
            }

            //Decide which direction is being taken.
            if (pcvm.Direction == "previous")
                return RedirectToAction("CoachPledge", pcvm.ApplicationID);
            if (pcvm.Direction == "next")
                return RedirectToAction("ID", pcvm.ApplicationID);

            //if all else fails, post back to the same page.
            return View(pcvm);
        }
        #endregion

        #region Application ID
        [HttpGet]
        public IActionResult ID(int AppID)
        {
            //Get the coaches current app
            Application currentApp = appRepo.GetApplicationByID(AppID);
            IDViewModel idvm = new IDViewModel();
            idvm.ApplicationID = AppID;
            //If any information exists, bind it to the view model.

            //Display the view.
            return View(idvm);
        }

        [HttpPost]
        public async Task<IActionResult> ID(IDViewModel idvm)
        {
            //Process all data that is in the view model. If anything is new or changed,
            //update the coaches current application.
            Application currentApp = appRepo.GetApplicationByID(idvm.ApplicationID);

            var uploads = Path.Combine(_environment.WebRootPath);
            if (idvm.File.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, idvm.File.FileName), FileMode.Create))
                {
                    await idvm.File.CopyToAsync(fileStream);
                }
                //p6Vm.Application.DlPath = $"\\{p6Vm.File.FileName}";
            }

            //Decide which direction is being taken.
            if (idvm.Direction == "previous")
            {
                if (currentApp.IsHeadCoach == true)
                    return RedirectToAction("PcaCourse", idvm.ApplicationID);
                else
                    return RedirectToAction("ConcussionCourse", idvm.ApplicationID);
            }
            if (idvm.Direction == "next")
                return RedirectToAction("Badge", idvm.ApplicationID);

            //if all else fails, post back to the same page.
            return View(idvm);
        }
        #endregion

        #region Application Badge
        [HttpGet]
        public IActionResult Badge(int AppID)
        {
            //Get the coaches current app
            Application currentApp = appRepo.GetApplicationByID(AppID);
            BadgeViewModel bvm = new BadgeViewModel();
            //If any information exists, bind it to the view model.

            //Display the view.
            return View(bvm);
        }

        [HttpPost]
        public async Task<IActionResult> Page7(BadgeViewModel bvm)
        {
            //Process all data that is in the view model. If anything is new or changed,
            //update the coaches current application.
            var uploads = Path.Combine(_environment.WebRootPath);
            if (bvm.File.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, bvm.File.FileName), FileMode.Create))
                {
                    await bvm.File.CopyToAsync(fileStream);
                }
                //p7Vm.Application.DlPath = $"\\{p7Vm.File.FileName}";
            }

            //Decide which direction is being taken.
            if (bvm.Direction == "previous")
                return RedirectToAction("ID", bvm.ApplicationID);
            //This is going to need to check if the user is an admin/sportsmanager since they have a different "index"
            if (bvm.Direction == "next")
                return RedirectToAction("Index");

            //if all else fails, post back to the same page.
            return View(bvm);
        }
        #endregion
        

    }
}
