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
    [Authorize]
    public class ApplicationController : Controller
    {
        private IHostingEnvironment _environment;
        private IApplicationRepo appRepo;
        private IUserRepo userRepo;
        private IStateRepo stateRepo;
        private ISportRepo sportRepo;
        private IAreaRepo areaRepo;
        private ISchoolRepo schoolRepo;
        private IGradeRepo gradeRepo;
        private IExpRepo expRepo;
        private IAppStatusRepo appStatusRepo;

        UserManager<User> userManager;

        public ApplicationController(UserManager<User> UM, IHostingEnvironment environment, IApplicationRepo apprepo, IUserRepo userrepo, IStateRepo staterepo, ISportRepo sportrepo, IAreaRepo arearepo, ISchoolRepo schoolrepo, IGradeRepo graderepo, IExpRepo exprepo, IAppStatusRepo appstatusrepo)
        {
            userManager = UM;
            _environment = environment;
            appRepo = apprepo;
            userRepo = userrepo;
            stateRepo = staterepo;
            sportRepo = sportrepo;
            areaRepo = arearepo;
            schoolRepo = schoolrepo;
            gradeRepo = graderepo;
            expRepo = exprepo;
            appStatusRepo = appstatusrepo;
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
                ivm.UserFirstName = user.FirstName;

                ivm.ApplicationID = 0;
                ivm.ApplicationStatus = new ApplicationStatus();
                ivm.Application = new Application();
                ivm.Application.IsHeadCoach = false;

                if (user.currentYearApp != null)
                {
                    ApplicationStatus appStatus = appStatusRepo.GetAppStatusByID(user.currentYearApp.ApplicationID);
                    DateTime renewalDate = new DateTime(DateTime.Now.Year, 6, 1).AddDays(-90);
                    if (appStatus.AppStartDate < renewalDate)
                    {
                        if (user.UserApplications == null)
                            user.UserApplications = new List<Application>();

                        user.UserApplications.Add(user.currentYearApp);

                        Application renewalApp = new Application();
                        renewalApp = user.currentYearApp;
                        renewalApp.AppGender = null;
                        renewalApp.AppArea = null;
                        renewalApp.AppGrade = null;
                        renewalApp.AppSchool = null;
                        renewalApp.AppSport = null;
                        renewalApp.NfhsPath = null;
                        renewalApp.PledgeInitials = null;
                        renewalApp.PledgeName = null;
                        renewalApp.pledgeIsInAgreement = false;
                        renewalApp.PledgeSubmissionDate = DateTime.Now;
                        renewalApp.YearsLivedInOregon += 1;

                        user.currentYearApp = renewalApp;
                        userRepo.Update(user);

                    } else
                    {
                        ivm.ApplicationStatus = appStatus;
                    }

                    int id = user.currentYearApp.ApplicationID;
                    ivm.ApplicationID = id;
                    ivm.Application = user.currentYearApp;
                    
                    return View(ivm);
                }
            }

            return View(ivm);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IndexViewModel ivm)
        {
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                user = userRepo.GetDetailedUser(user);
            }

            if (ivm.ApplicationID == 0)
            {
                Application app = new Application();
                appRepo.CreateApp(app);

                ApplicationStatus appstatus = new ApplicationStatus();
                appstatus.AppStartDate = DateTime.Now;
                appstatus.ApplicationID = app.ApplicationID;
                appStatusRepo.Create(appstatus);

                ivm.ApplicationID = app.ApplicationID;
                if (user != null)
                {
                    user.currentYearApp = app;
                    userRepo.Update(user);
                }
                return RedirectToAction("CoachInfo", new { AppID = ivm.ApplicationID });
            }

            //This will probably need to include all of your past application id's as well. so users can view their own past apps.
            if (user.currentYearApp.ApplicationID == ivm.ApplicationID || User.IsInRole("Admin") || User.IsInRole("SportsManager"))
            {
                if (ivm.ApplicationID != 0)
                {
                    ivm.ApplicationStatus = appStatusRepo.GetAppStatusByID(ivm.ApplicationID);

                    /* Use app id to do stuff */
                    if (ivm.PageName == "Information")
                        return RedirectToAction("CoachInfo", new { AppID = ivm.ApplicationID });
                    if (ivm.PageName == "Interests")
                        return RedirectToAction("CoachInterests", new { AppID = ivm.ApplicationID });
                    if (ivm.PageName == "Pledge")
                        return RedirectToAction("CoachPledge", new { AppID = ivm.ApplicationID });
                    if (ivm.PageName == "NFHS Course")
                        return RedirectToAction("ConcussionCourse", new { AppID = ivm.ApplicationID });
                    if (ivm.PageName == "PCA Course")
                        return RedirectToAction("PcaCourse", new { AppID = ivm.ApplicationID });
                    if (ivm.PageName == "ID")
                        return RedirectToAction("ID", new { AppID = ivm.ApplicationID });
                    if (ivm.PageName == "Badge")
                        return RedirectToAction("Badge", new { AppID = ivm.ApplicationID });
                    return View(ivm);
                }
            }
            else
                return RedirectToAction("AccessDenied", "Account");

            return View(ivm);
        }

        #endregion

        #region SportsManager Views
        [HttpGet]
        [Authorize(Roles = "SportsManager, Admin")]
        public IActionResult Applications()
        {
            //Get the sports manager and put their area in the search model by default.
            ApplicationSearchModel asm = new ApplicationSearchModel();
            asm.filteredApps = new List<Application>();
            asm.filteredUsers = new List<User>();
            asm.filteredAppStatus = new List<ApplicationStatus>();
            asm.Grade = new List<int>();
            asm.Sport = new List<int>();
            asm.Area = new List<int>();
            asm.School = new List<int>();

            List<Application> filteredApps = appRepo.GetFilteredApplications(asm).ToList();
            List<User> filteredUsers = new List<User>();
            List<ApplicationStatus> filteredAppStatus = new List<ApplicationStatus>();

            foreach (Application a in filteredApps)
            {
                User u = userRepo.GetUserByID(a.ApplicationID);
                ApplicationStatus appstatus = appStatusRepo.GetAppStatusByID(a.ApplicationID);

                filteredUsers.Add(u);
                filteredAppStatus.Add(appstatus);
            }

            if (filteredApps != null)
                asm.filteredApps.AddRange(filteredApps);
            else
                asm.filteredApps = new List<Application>();

            if (filteredUsers != null)
                asm.filteredUsers.AddRange(filteredUsers);
            else
                asm.filteredUsers = new List<User>();

            if (filteredAppStatus != null)
                asm.filteredAppStatus.AddRange(filteredAppStatus);
            else
                asm.filteredAppStatus = new List<ApplicationStatus>();

            asm.allAreas = areaRepo.GetAllAreas();
            asm.allSchools = schoolRepo.GetAllSchools();
            asm.allSports = sportRepo.GetAllSports();
            asm.allGrades = gradeRepo.GetAllGrades();

            //asm.Area = new List<int>();
            //asm.School = new List<int>();
            //asm.Sport = new List<int>();
            //asm.Grade = new List<int>();

            //foreach (Area i in asmArea)
            //    asm.Area.Add(i.AreaID);

            //foreach (School i in asmSchool)
            //    asm.School.Add(i.SchoolID);

            //foreach (Sport i in asmSport)
            //    asm.Sport.Add(i.SportID);

            //foreach (Grade i in asmGrade)
            //    asm.Grade.Add(i.GradeID);

            return View(asm);
        }

        [HttpPost]
        [Authorize(Roles = "SportsManager, Admin")]
        public IActionResult Applications(ApplicationSearchModel asm = null)
        {
            if (asm == null)
                asm = new ApplicationSearchModel();
            asm.filteredApps = new List<Application>();
            asm.filteredUsers = new List<User>();
            asm.filteredAppStatus = new List<ApplicationStatus>();

            List<Application> filteredApps = appRepo.GetFilteredApplications(asm).ToList();
            List<User> filteredUsers = new List<User>();
            List<ApplicationStatus> filteredAppStatus = new List<ApplicationStatus>();

            foreach (Application a in filteredApps)
            {
                User u = userRepo.GetUserByID(a.ApplicationID);
                ApplicationStatus appstatus = appStatusRepo.GetAppStatusByID(a.ApplicationID);

                filteredUsers.Add(u);
                filteredAppStatus.Add(appstatus);
            }

            if (filteredApps != null)
                asm.filteredApps.AddRange(filteredApps);
            else
                asm.filteredApps = new List<Application>();

            if (filteredUsers != null)
                asm.filteredUsers.AddRange(filteredUsers);
            else
                asm.filteredUsers = new List<User>();

            if (filteredAppStatus != null)
                asm.filteredAppStatus.AddRange(filteredAppStatus);
            else
                asm.filteredAppStatus = new List<ApplicationStatus>();
            return View(asm);
        }


        [HttpGet]
        [Authorize(Roles = "SportsManager, Admin")]
        public IActionResult ApplicantDetails(string ApplicantID, int? displayAppID)
        {
            ApplicantDetailsViewModel advm = new ApplicantDetailsViewModel();
            User appuser = userRepo.GetUserByIdentityID(ApplicantID);
            userRepo.GetDetailedUser(appuser);
            Application currentApp = appuser.currentYearApp;

            if (displayAppID == null)
                advm.displayApp = currentApp;
            else
                advm.displayApp = appRepo.GetApplicationByID((int)displayAppID);

            ApplicationStatus appstatus = appStatusRepo.GetAppStatusByID(advm.displayApp.ApplicationID);
            advm.applicant = appuser;
            advm.ApplicationStatus = appstatus;

            advm.allUserApps = new List<ApplicationStatus>();

            if (appuser.UserApplications == null)
            {
                appuser.UserApplications = new List<Application>();
                userRepo.Update(appuser);
            }

            foreach(Application app in appuser.UserApplications)
            {
                advm.allUserApps.Add(appStatusRepo.GetAppStatusByID(app.ApplicationID));
            }
            advm.allUserApps.Add(appStatusRepo.GetAppStatusByID(appuser.currentYearApp.ApplicationID));

            return View(advm);
        }

        [HttpPost]
        [Authorize(Roles = "SportsManager, Admin")]
        public IActionResult ApplicantDetails(ApplicantDetailsViewModel advm)
        {
            if (advm.PageName == "Information")
                return RedirectToAction("CoachInfo", new { AppID = advm.appID });
            if (advm.PageName == "Interests")
                return RedirectToAction("CoachInterests", new { AppID = advm.appID });
            if (advm.PageName == "Pledge")
                return RedirectToAction("CoachPledge", new { AppID = advm.appID });
            if (advm.PageName == "NFHS Course")
                return RedirectToAction("ConcussionCourse", new { AppID = advm.appID });
            if (advm.PageName == "PCA Course")
                return RedirectToAction("PcaCourse", new { AppID = advm.appID });
            if (advm.PageName == "ID")
                return RedirectToAction("ID", new { AppID = advm.appID });
            if (advm.PageName == "Badge")
                return RedirectToAction("Badge", new { AppID = advm.appID });
            return View(advm);
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
        public async Task<IActionResult> CoachInfo(int AppID)
        {
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                user = userRepo.GetDetailedUser(user);
            }

            //This will probably need to include all of your past application id's as well. so users can view their own past apps.
            if (User.IsInRole("Admin") || User.IsInRole("SportsManager") || user.currentYearApp.ApplicationID == AppID)
            {
                //Get the coaches current app
                Application currentApp = appRepo.GetApplicationByID(AppID);


                CoachInfoViewModel civm = new CoachInfoViewModel();

                #region Bind application to view model if pre-exisiting info
                //If any information exists, bind it to the view model.
                civm.ApplicationID = AppID;

                //if (!User.IsInRole("Admin") && !User.IsInRole("Sports Manager"))
                //{
                if (!User.IsInRole("SportsManager") && !User.IsInRole("Admin"))
                {

                    if (user.FirstName != null) civm.FirstName = user.FirstName;
                    if (user.MiddleName != null) civm.MiddleName = user.MiddleName;
                    if (user.LastName != null) civm.LastName = user.LastName;
                    if (user.PreviousLastName1 != null) civm.PreviousLastName1 = user.PreviousLastName1;
                    if (user.PreviousLastName2 != null) civm.PreviousLastName2 = user.PreviousLastName2;
                    if (user.PreviousLastName3 != null) civm.PreviousLastName3 = user.PreviousLastName3;
                    if (user.PhoneNumber != null) civm.CellPhone = user.PhoneNumber;
                    if (user.AlternatePhone != null) civm.AlternatePhone = user.AlternatePhone;
                    if (user.PreferredName != null) civm.PreferredName = user.PreferredName;

                }
                else
                {
                    User appuser = userRepo.GetUserByID(AppID);
                    civm.FirstName = appuser.FirstName;
                    civm.MiddleName = appuser.MiddleName;
                    civm.LastName = appuser.LastName;
                    civm.PreviousLastName1 = appuser.PreviousLastName1;
                    civm.PreviousLastName2 = appuser.PreviousLastName2;
                    civm.PreviousLastName3 = appuser.PreviousLastName3;
                    civm.PreferredName = appuser.PreferredName;
                    civm.CellPhone = appuser.PhoneNumber;
                    civm.AlternatePhone = appuser.AlternatePhone;
                }

                if (currentApp.DOB != null && currentApp.DOB != new DateTime()) civm.DOB = currentApp.DOB; else civm.DOB = DateTime.Now;

                if (currentApp.YearsLivedInOregon != -1) civm.YearsLivingInOregon = currentApp.YearsLivedInOregon;
                if (currentApp.Address != null) civm.Address = currentApp.Address;
                if (currentApp.City != null) civm.City = currentApp.City;
                if (currentApp.State != null) civm.State = currentApp.State; else civm.State = new State();
                if (currentApp.ZipCode != null) civm.Zip = currentApp.ZipCode;
                if (currentApp.LivedOutsideUSA != false) civm.HasLivedOutsideUSA = currentApp.LivedOutsideUSA;

                if (currentApp.City != null) civm.City = currentApp.City;
                if (currentApp.State != null) civm.State = currentApp.State;
                if (currentApp.Address != null) civm.Address = currentApp.Address;
                if (currentApp.CurrentEmployer != null) civm.CurrentEmployer = currentApp.CurrentEmployer;
                if (currentApp.JobTitle != null) civm.JobTitle = currentApp.JobTitle;
                civm.YearsLivingInOregon = currentApp.YearsLivedInOregon;

                civm.AllStates = stateRepo.GetAllStates();
                if (currentApp.StatesLived != null)
                {
                    foreach (AppStateJoin a in currentApp.StatesLived)
                        civm.PreviousStates.Add(a.StateID);
                }
                else
                {
                    civm.PreviousStates = new List<int>();
                }
                #endregion

                //Display the view.
                return View(civm);
            }
            else
                return RedirectToAction("AccessDenied", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> CoachInfo(CoachInfoViewModel civm)
        {
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                user = userRepo.GetDetailedUser(user);
            }

            //This will probably need to include all of your past application id's as well. so users can view their own past apps.
            if (User.IsInRole("Admin") || User.IsInRole("SportsManager") || user.currentYearApp.ApplicationID == civm.ApplicationID)
            {
                //Process all data that is in the view model. If anything is new or changed,
                //update the coaches current application.
                Application currentApp = appRepo.GetApplicationByID(civm.ApplicationID);
                #region Bind VM to application
                if (civm.FirstName != null) user.FirstName = civm.FirstName;
                if (civm.LastName != null) user.LastName = civm.LastName;
                if (civm.MiddleName != null) user.MiddleName = civm.MiddleName;
                if (civm.PreviousLastName1 != null) user.PreviousLastName1 = civm.PreviousLastName1;
                if (civm.PreviousLastName2 != null) user.PreviousLastName2 = civm.PreviousLastName2;
                if (civm.PreviousLastName3 != null) user.PreviousLastName3 = civm.PreviousLastName3;
                if (civm.PreferredName != null) user.PreferredName = civm.PreferredName;
                if (civm.CellPhone != null) user.PhoneNumber = civm.CellPhone;
                if (civm.AlternatePhone != null) user.AlternatePhone = civm.AlternatePhone;
                currentApp.LivedOutsideUSA = civm.HasLivedOutsideUSA;

                if (civm.newPickedStateID != -1) currentApp.State = stateRepo.GetStateByID(civm.newPickedStateID);
                if (civm.PreviousStates != null && civm.PreviousStates.Count != 0)
                {
                    if (currentApp.StatesLived == null) currentApp.StatesLived = new List<AppStateJoin>();
                    foreach (int sid in civm.PreviousStates)
                        currentApp.StatesLived.Add(new AppStateJoin() { ApplicationID = currentApp.ApplicationID, StateID = sid });
                }
                if (civm.DOB != null && civm.DOB != DateTime.Now) currentApp.DOB = (DateTime)civm.DOB;
                if (civm.Address != null) currentApp.Address = civm.Address;
                if (civm.City != null) currentApp.City = civm.City;
                if (civm.Zip != null) currentApp.ZipCode = civm.Zip;
                if (civm.CurrentEmployer != null) currentApp.CurrentEmployer = civm.CurrentEmployer;
                if (civm.JobTitle != null) currentApp.JobTitle = civm.JobTitle;

                if (civm.YearsLivingInOregon != -1) currentApp.YearsLivedInOregon = civm.YearsLivingInOregon;
                appRepo.Update(currentApp);

                #endregion

                userRepo.Update(user);

                #region App Status
                ApplicationStatus appStatus = appStatusRepo.GetAppStatusByID(currentApp.ApplicationID);

                if ((appStatus.CoachInfoSubmissionDate == null ||
                    appStatus.CoachInfoSubmissionDate == new DateTime()) &&
                    (civm.Address != "" && civm.Address != null) &&
                    (civm.CellPhone != "" && civm.CellPhone != null) &&
                    (civm.City != "" && civm.City != null) &&
                    (civm.CurrentEmployer != "" && civm.CurrentEmployer != null) &&
                    (civm.DOB != new DateTime() && civm.DOB != DateTime.Now) &&
                    (civm.FirstName != "" && civm.FirstName != null) &&
                    (civm.MiddleName != "" && civm.MiddleName != null) &&
                    (civm.LastName != "" && civm.LastName != null) &&
                     civm.newPickedStateID != -1 &&
                    (civm.JobTitle != "" && civm.Address != null) &&
                     civm.YearsLivingInOregon != -1 &&
                    (civm.Zip != "" && civm.Zip != null))
                {
                    appStatus.CoachInfoSubmissionDate = DateTime.Now;
                    appStatusRepo.Update(appStatus);
                }
                #endregion

                if (civm.Direction == "approve")
                {
                    if (appStatus.CoachInfoApprovalDate == null || appStatus.CoachInfoApprovalDate == new DateTime())
                    {
                        appStatus.CoachInfoApprovalDate = DateTime.Now;
                        if (appStatus.CoachInfoDenialDate != null && appStatus.CoachInfoDenialDate != new DateTime())
                            appStatus.CoachInfoDenialDate = null;

                        appStatusRepo.Update(appStatus);
                    }

                    return RedirectToAction("CoachInterests", new { AppID = civm.ApplicationID });
                }

                if (civm.Direction == "deny")
                {
                    if (appStatus.CoachInfoDenialDate == null || appStatus.CoachInfoDenialDate == new DateTime())
                    {
                        appStatus.CoachInfoDenialDate = DateTime.Now;
                        if (appStatus.CoachInfoApprovalDate != null && appStatus.CoachInfoApprovalDate != new DateTime())
                            appStatus.CoachInfoApprovalDate = null;

                        appStatusRepo.Update(appStatus);
                    }

                    User appuser = userRepo.GetUserByID(civm.ApplicationID);
                    return RedirectToAction("ApplicantDetails", new { ApplicantID = appuser.Id });
                }
                //Decide which direction is being taken (this page only has next).
                if (civm.Direction == "next")
                    return RedirectToAction("CoachInterests", new { AppID = civm.ApplicationID });

                //if all else fails, post back to the same page.
                return View(civm);
            }
            else
                return RedirectToAction("AccessDenied", "Account");
        }
        #endregion

        #region Application Coach Interests
        [HttpGet]
        public async Task<IActionResult> CoachInterests(int AppID)
        {
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                user = userRepo.GetDetailedUser(user);
            }

            //This will probably need to include all of your past application id's as well. so users can view their own past apps.
            if (User.IsInRole("Admin") || User.IsInRole("SportsManager") || user.currentYearApp.ApplicationID == AppID)
            {
                //Get the coaches current app
                Application currentApp = appRepo.GetApplicationByID(AppID);
                CoachInterestViewModel civm = new CoachInterestViewModel();

                #region Bind application to view model if pre-exisiting info
                //If any information exists, bind it to the view model.
                civm.ApplicationID = AppID;
                civm.AllSports = sportRepo.GetAllSports();
                civm.AllAreas = areaRepo.GetAllAreas();
                if (civm.Area != null)
                    civm.SchoolsByArea = schoolRepo.GetSchoolsByArea(civm.Area);
                else civm.SchoolsByArea = schoolRepo.GetAllSchools();
                civm.AllGrades = gradeRepo.GetAllGrades();
                civm.AllExperience = expRepo.GetAllExperiences();

                if (currentApp.AppArea != null) civm.Area = currentApp.AppArea; else civm.Area = new Area();
                if (currentApp.IsHeadCoach != false) civm.IsHeadCoach = currentApp.IsHeadCoach;
                if (currentApp.IsAssistantCoach != false) civm.IsAssistantCoach = currentApp.IsAssistantCoach;
                if (currentApp.AppSport != null) civm.Sport = currentApp.AppSport; else civm.Sport = new Sport();
                if (currentApp.AppGender != null) civm.Gender = currentApp.AppGender;
                if (currentApp.AppSchool != null) civm.School = currentApp.AppSchool; else civm.School = new School();
                if (currentApp.AppGrade != null) civm.GradePreference = currentApp.AppGrade;
                if (currentApp.NameOfChild != null) civm.ChildTeam = currentApp.NameOfChild;
                if (currentApp.YearsExperience != -1) civm.YearsExperience = currentApp.YearsExperience;

                if (civm.PreviousExperience == null & currentApp.PreviousExperience != null)
                {
                    civm.PreviousExperience = new List<int>();
                    foreach (AppExpJoin ae in currentApp.PreviousExperience)
                        civm.PreviousExperience.Add(ae.ExperienceID);
                }
                else
                    civm.PreviousExperience = new List<int>();
                #endregion

                //Display the view.
                return View(civm);
            }
            else
                return RedirectToAction("AccessDenied", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> CoachInterests(CoachInterestViewModel civm)
        {
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                user = userRepo.GetDetailedUser(user);
            }

            //This will probably need to include all of your past application id's as well. so users can view their own past apps.
            if (User.IsInRole("Admin") || User.IsInRole("SportsManager") || user.currentYearApp.ApplicationID == civm.ApplicationID)
            {
                Application currentApp = appRepo.GetApplicationByID(civm.ApplicationID);
                if (civm.newPickedAreaID != -1) currentApp.AppArea = areaRepo.GetAreaByID(civm.newPickedAreaID);
                if (civm.Gender != null) currentApp.AppGender = civm.Gender;
                if (civm.GradePreference != null) currentApp.AppGrade = civm.GradePreference;
                if (civm.ChildTeam != null) currentApp.NameOfChild = civm.ChildTeam;
                if (civm.newPickedSportID != -1) currentApp.AppSport = sportRepo.GetSportsByID(civm.newPickedSportID);
                if (civm.YearsExperience != -1) currentApp.YearsExperience = civm.YearsExperience;
                currentApp.IsHeadCoach = civm.IsHeadCoach;
                currentApp.IsAssistantCoach = civm.IsAssistantCoach;
                if (civm.newPickedSchoolID != -1) currentApp.AppSchool = schoolRepo.GetSchoolByID(civm.newPickedSchoolID);
                if (civm.newPickedSportID != -1) currentApp.AppSport = sportRepo.GetSportsByID(civm.newPickedSportID);

                if (civm.PreviousExperience != null)
                {
                    if (currentApp.PreviousExperience == null) currentApp.PreviousExperience = new List<AppExpJoin>();
                    foreach (int exp in civm.PreviousExperience)
                        currentApp.PreviousExperience.Add(new AppExpJoin() { ApplicationID = currentApp.ApplicationID, ExperienceID = exp });
                }


                appRepo.Update(currentApp);


                #region App Status
                ApplicationStatus appStatus = appStatusRepo.GetAppStatusByID(currentApp.ApplicationID);

                if ((appStatus.CoachInterestSubmissionDate == null ||
                    appStatus.CoachInterestSubmissionDate == new DateTime()) &&
                    civm.newPickedAreaID != -1 &&
                    (civm.Gender != "" && civm.Gender != null) &&
                    (civm.GradePreference != "" && civm.GradePreference != null) &&
                    civm.newPickedSportID != -1 &&
                    civm.newPickedSchoolID != -1 &&
                    civm.YearsExperience != -1)
                {
                    appStatus.CoachInterestSubmissionDate = DateTime.Now;
                    appStatusRepo.Update(appStatus);
                }
                #endregion


                //Decide which direction is being taken.
                if (civm.Direction == "approve")
                {
                    if (appStatus.CoachInterestApprovalDate == null || appStatus.CoachInterestApprovalDate == new DateTime())
                    {
                        appStatus.CoachInterestApprovalDate = DateTime.Now;
                        appStatusRepo.Update(appStatus);
                    }

                    return RedirectToAction("CoachPledge", new { AppID = civm.ApplicationID });
                }

                if (civm.Direction == "deny")
                {
                    if (appStatus.CoachInterestDenialDate == null || appStatus.CoachInterestDenialDate == new DateTime())
                    {
                        appStatus.CoachInterestDenialDate = DateTime.Now;
                        if (appStatus.CoachInterestApprovalDate != null && appStatus.CoachInterestApprovalDate != new DateTime())
                            appStatus.CoachInterestApprovalDate = null;

                        appStatusRepo.Update(appStatus);
                    }

                    User appuser = userRepo.GetUserByID(civm.ApplicationID);
                    return RedirectToAction("ApplicantDetails", new { ApplicantID = appuser.Id });
                }

                if (civm.Direction == "previous")
                    return RedirectToAction("CoachInfo", new { AppID = civm.ApplicationID });
                if (civm.Direction == "next")
                    return RedirectToAction("CoachPledge", new { AppID = civm.ApplicationID });

                //if all else fails, post back to the same page.
                return View(civm);
            }
            else
                return RedirectToAction("AccessDenied", "Account");
        }
        #endregion

        #region Application Coach Pledge
        [HttpGet]
        public async Task<IActionResult> CoachPledge(int AppID)
        {
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                user = userRepo.GetDetailedUser(user);
            }

            //This will probably need to include all of your past application id's as well. so users can view their own past apps.
            if (User.IsInRole("Admin") || User.IsInRole("SportsManager") || user.currentYearApp.ApplicationID == AppID)
            {
                //Get the coaches current app
                Application currentApp = appRepo.GetApplicationByID(AppID);
                CoachPledgeViewModel cpvm = new CoachPledgeViewModel();

                //If any information exists, bind it to the view model.
                cpvm.ApplicationID = AppID;
                if (currentApp.PledgeName != null) cpvm.Name = currentApp.PledgeName;
                if (currentApp.PledgeInitials != null) cpvm.Initials = currentApp.PledgeInitials;
                if (currentApp.pledgeIsInAgreement != false) cpvm.IsInAgreement = currentApp.pledgeIsInAgreement;
                if (currentApp.PledgeSubmissionDate != new DateTime()) cpvm.PledgeSubmissionDate = currentApp.PledgeSubmissionDate;

                //Display the view.
                return View(cpvm);
            }
            else
                return RedirectToAction("AccessDenied", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> CoachPledge(CoachPledgeViewModel cpvm)
        {
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                user = userRepo.GetDetailedUser(user);
            }

            //This will probably need to include all of your past application id's as well. so users can view their own past apps.
            if (User.IsInRole("Admin") || User.IsInRole("SportsManager") || user.currentYearApp.ApplicationID == cpvm.ApplicationID)
            {
                //Process all data that is in the view model. If anything is new or changed,
                //update the coaches current application.
                Application currentApp = appRepo.GetApplicationByID(cpvm.ApplicationID);
                if (cpvm.Name != null) currentApp.PledgeName = cpvm.Name;
                if (cpvm.Initials != null) currentApp.PledgeInitials = cpvm.Initials;
                if (cpvm.IsInAgreement != false) currentApp.pledgeIsInAgreement = cpvm.IsInAgreement;
                if (cpvm.PledgeSubmissionDate != null) currentApp.PledgeSubmissionDate = (DateTime)cpvm.PledgeSubmissionDate;
                appRepo.Update(currentApp);

                #region App Status
                ApplicationStatus appStatus = appStatusRepo.GetAppStatusByID(currentApp.ApplicationID);

                if ((appStatus.PledgeSubmissionDate == null ||
                    appStatus.PledgeSubmissionDate == new DateTime()) &&
                    //TODO check if name is correct
                    cpvm.Name != "" &&
                    cpvm.IsInAgreement == true &&
                    //TODO check if initials are correct
                    cpvm.Initials != "" &&
                    cpvm.PledgeSubmissionDate != null)
                {
                    appStatus.PledgeSubmissionDate = DateTime.Now;
                    appStatusRepo.Update(appStatus);
                }
                #endregion

                //Decide which direction is being taken.
                if (cpvm.Direction == "approve")
                {
                    if (appStatus.PledgeApprovalDate == null || appStatus.PledgeApprovalDate == new DateTime())
                        appStatus.PledgeApprovalDate = DateTime.Now;
                    if (appStatus.PledgeDenialDate != null || appStatus.PledgeDenialDate != new DateTime())
                        appStatus.PledgeDenialDate = null;

                    appStatusRepo.Update(appStatus);
                    return RedirectToAction("ConcussionCourse", new { AppID = cpvm.ApplicationID });
                }

                if (cpvm.Direction == "deny")
                {
                    if (appStatus.PledgeDenialDate == null || appStatus.PledgeDenialDate == new DateTime())
                    {
                        appStatus. PledgeDenialDate = DateTime.Now;
                        if (appStatus.PledgeApprovalDate != null && appStatus.PledgeApprovalDate != new DateTime())
                            appStatus.PledgeApprovalDate = null;

                        appStatusRepo.Update(appStatus);
                    }

                    User appuser = userRepo.GetUserByID(cpvm.ApplicationID);
                    return RedirectToAction("ApplicantDetails", new { ApplicantID = appuser.Id });
                }
                if (cpvm.Direction == "previous")
                    return RedirectToAction("CoachInterests", new { AppID = cpvm.ApplicationID });
                if (cpvm.Direction == "next")
                    return RedirectToAction("ConcussionCourse", new { AppID = cpvm.ApplicationID });

                //if all else fails, post back to the same page.
                return View(cpvm);
            }
            else
                return RedirectToAction("AccessDenied", "Account");
        }
        #endregion

        #region Application Concussion Course
        [HttpGet]
        public async Task<IActionResult> ConcussionCourse(int AppID)
        {
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                user = userRepo.GetDetailedUser(user);
            }

            //This will probably need to include all of your past application id's as well. so users can view their own past apps.
            if (User.IsInRole("Admin") || User.IsInRole("SportsManager") || user.currentYearApp.ApplicationID == AppID)
            {
                //Get the coaches current app
                Application currentApp = appRepo.GetApplicationByID(AppID);
                ConcussionCourseViewModel ccvm = new ConcussionCourseViewModel();
                ccvm.ApplicationID = AppID;
                //If any information exists, bind it to the view model.
                // if (currentApp.ConcussionCourseSubmissionDate != new DateTime()) ccvm.ConcussionCourseSubmissionDate = currentApp.ConcussionCourseSubmissionDate;
                if (currentApp.NfhsPath != null) ccvm.NfhsPath = currentApp.NfhsPath;
                if (currentApp.ConcussionCourseSubmissionDate != new DateTime()) ccvm.ConcussionCourseSubmissionDate = currentApp.ConcussionCourseSubmissionDate;

                //Display the view.
                return View(ccvm);
            }
            else
                return RedirectToAction("AccessDenied", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> ConcussionCourse(ConcussionCourseViewModel ccvm)
        {
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                user = userRepo.GetDetailedUser(user);
            }

            //This will probably need to include all of your past application id's as well. so users can view their own past apps.
            if (User.IsInRole("Admin") || User.IsInRole("SportsManager") || user.currentYearApp.ApplicationID == ccvm.ApplicationID)
            {
                //Process all data that is in the view model. If anything is new or changed,
                //update the coaches current application.
                Application currentApp = appRepo.GetApplicationByID(ccvm.ApplicationID);
                if (ccvm.ConcussionCourseSubmissionDate != null) currentApp.ConcussionCourseSubmissionDate = (DateTime)ccvm.ConcussionCourseSubmissionDate;
                if (currentApp.NfhsPath != null)
                {
                    //get the image and put it in the view model.
                }

                try
                {
                    var uploads = Path.Combine(_environment.WebRootPath, "Images", "ConcussionCourse");
                    if (ccvm.File.Length > 0)
                    {
                        var pathName = ccvm.File.FileName;
                        var parts = pathName.Split('.');
                        int partsCount = parts.Count();
                        var extension = parts[partsCount - 1];
                        using (var fileStream = new FileStream(Path.Combine(uploads, ccvm.ApplicationID.ToString() + "." + extension), FileMode.Create))
                        {
                            await ccvm.File.CopyToAsync(fileStream);
                            currentApp.NfhsPath = "..\\Images\\ConcussionCourse\\" + currentApp.ApplicationID.ToString()+ "." + extension;
                        }
                    }
                }
                catch (Exception e)
                {
                    //Add model state error? validation?
                }
                appRepo.Update(currentApp);

                #region App Status
                ApplicationStatus appStatus = appStatusRepo.GetAppStatusByID(currentApp.ApplicationID);

                if ((appStatus.NFHSSubmissionDate == null ||
                    appStatus.NFHSSubmissionDate == new DateTime()) &&
                    (currentApp.NfhsPath != null && currentApp.NfhsPath != "") &&
                    ccvm.ConcussionCourseSubmissionDate != null)
                {
                    appStatus.NFHSSubmissionDate = DateTime.Now;
                    appStatusRepo.Update(appStatus);
                }
                #endregion

                //Decide which direction is being taken.
                if (ccvm.Direction == "approve")
                {
                    if (appStatus.NFHSApprovalDate == null || appStatus.NFHSApprovalDate == new DateTime())
                        appStatus.NFHSApprovalDate = DateTime.Now;
                    if (appStatus.NFHSDenialDate != null || appStatus.NFHSDenialDate != new DateTime())
                        appStatus.NFHSDenialDate = null;

                    appStatusRepo.Update(appStatus);
                    if (currentApp.IsHeadCoach == true)
                        return RedirectToAction("PcaCourse", new { AppID = ccvm.ApplicationID });
                    else
                        return RedirectToAction("ID", new { AppID = ccvm.ApplicationID });
                }

                if (ccvm.Direction == "deny")
                {
                    if (appStatus.NFHSDenialDate == null || appStatus.NFHSDenialDate == new DateTime())
                    {
                        appStatus.NFHSDenialDate = DateTime.Now;
                        if (appStatus.NFHSApprovalDate != null && appStatus.NFHSApprovalDate != new DateTime())
                            appStatus.NFHSApprovalDate = null;

                        appStatusRepo.Update(appStatus);
                    }

                    User appuser = userRepo.GetUserByID(ccvm.ApplicationID);
                    return RedirectToAction("ApplicantDetails", new { ApplicantID = appuser.Id });
                }
                if (ccvm.Direction == "previous")
                    return RedirectToAction("CoachPledge", new { AppID = ccvm.ApplicationID });
                if (ccvm.Direction == "next")
                {
                    if (currentApp.IsHeadCoach == true)
                        return RedirectToAction("PcaCourse", new { AppID = ccvm.ApplicationID });
                    else
                        return RedirectToAction("ID", new { AppID = ccvm.ApplicationID });
                }

                //if all else fails, post back to the same page.
                return View(ccvm);
            }
            else
                return RedirectToAction("AccessDenied", "Account");
        }
        #endregion

        #region Application Pca Course
        [HttpGet]
        public async Task<IActionResult> PcaCourse(int AppID)
        {
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                user = userRepo.GetDetailedUser(user);
            }

            //This will probably need to include all of your past application id's as well. so users can view their own past apps.
            if (User.IsInRole("Admin") || User.IsInRole("SportsManager") || user.currentYearApp.ApplicationID == AppID)
            {
                //Get the coaches current app
                Application currentApp = appRepo.GetApplicationByID(AppID);
                PcaCourseViewModel pcvm = new PcaCourseViewModel();
                pcvm.ApplicationID = AppID;
                //If any information exists, bind it to the view model.
                if (currentApp.PcaPath != null) pcvm.PcaPath = currentApp.PcaPath; else pcvm.PcaPath = "";

                //Display the view.
                return View(pcvm);
            }
            else
                return RedirectToAction("AccessDenied", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> PcaCourse(PcaCourseViewModel pcvm)
        {
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                user = userRepo.GetDetailedUser(user);
            }

            //This will probably need to include all of your past application id's as well. so users can view their own past apps.
            if (User.IsInRole("Admin") || User.IsInRole("SportsManager") || user.currentYearApp.ApplicationID == pcvm.ApplicationID)
            {
                Application currentApp = appRepo.GetApplicationByID(pcvm.ApplicationID);

                //Process all data that is in the view model. If anything is new or changed,
                //update the coaches current application.
                var uploads = Path.Combine(_environment.WebRootPath, "Images", "PCACourse");
                try
                {
                    if (pcvm.File.Length > 0)
                    {
                        using (var fileStream = new FileStream(Path.Combine(uploads, pcvm.ApplicationID.ToString() + ".jpg"), FileMode.Create))
                        {
                            await pcvm.File.CopyToAsync(fileStream);
                            currentApp.PcaPath = "..\\Images\\PcaCourse\\" + currentApp.ApplicationID.ToString() + ".jpg";
                        }
                    }
                }
                catch (Exception e)
                {

                }
                appRepo.Update(currentApp);

                #region App Status
                ApplicationStatus appStatus = appStatusRepo.GetAppStatusByID(currentApp.ApplicationID);

                if ((appStatus.PcaSubmissionDate == null ||
                    appStatus.PcaSubmissionDate == new DateTime()) &&
                    pcvm.PcaPath != "" &&
                    pcvm.PcaCourseSubmissionDate != null)
                {
                    appStatus.PcaSubmissionDate = DateTime.Now;
                    appStatusRepo.Update(appStatus);
                }
                #endregion

                //Decide which direction is being taken.
                if (pcvm.Direction == "approve")
                {
                    if (appStatus.PcaApprovalDate == null || appStatus.PcaApprovalDate == new DateTime())
                        appStatus.PcaApprovalDate = DateTime.Now;
                    if (appStatus.PcaDenialDate != null || appStatus.PcaDenialDate != new DateTime())
                        appStatus.PcaDenialDate = null;

                    appStatusRepo.Update(appStatus);
                    return RedirectToAction("ID", new { AppID = pcvm.ApplicationID });
                }

                if (pcvm.Direction == "deny")
                {
                    if (appStatus.PcaDenialDate == null || appStatus.PcaDenialDate == new DateTime())
                    {
                        appStatus.PcaDenialDate = DateTime.Now;
                        if (appStatus.PcaApprovalDate != null && appStatus.PcaApprovalDate != new DateTime())
                            appStatus.PcaApprovalDate = null;

                        appStatusRepo.Update(appStatus);
                    }

                    User appuser = userRepo.GetUserByID(pcvm.ApplicationID);
                    return RedirectToAction("ApplicantDetails", new { ApplicantID = appuser.Id });
                }
                if (pcvm.Direction == "previous")
                    return RedirectToAction("ConcussionCourse", new { AppID = pcvm.ApplicationID });
                if (pcvm.Direction == "next")
                    return RedirectToAction("ID", new { AppID = pcvm.ApplicationID });

                //if all else fails, post back to the same page.
                return View(pcvm);
            }
            else
                return RedirectToAction("AccessDenied", "Account");
        }
        #endregion

        #region Application ID
        [HttpGet]
        public async Task<IActionResult> ID(int AppID)
        {
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                user = userRepo.GetDetailedUser(user);
            }

            //This will probably need to include all of your past application id's as well. so users can view their own past apps.
            if (User.IsInRole("Admin") || User.IsInRole("SportsManager") || user.currentYearApp.ApplicationID == AppID)
            {
                //Get the coaches current app
                Application currentApp = appRepo.GetApplicationByID(AppID);
                IDViewModel idvm = new IDViewModel();
                idvm.ApplicationID = AppID;
                //If any information exists, bind it to the view model.
                if (currentApp.DlPath != null) idvm.IDPath = currentApp.DlPath;

                //Display the view.
                return View(idvm);
            }
            else
                return RedirectToAction("AccessDenied", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> ID(IDViewModel idvm)
        {
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                user = userRepo.GetDetailedUser(user);
            }

            //This will probably need to include all of your past application id's as well. so users can view their own past apps.
            if (User.IsInRole("Admin") || User.IsInRole("SportsManager") || user.currentYearApp.ApplicationID == idvm.ApplicationID)
            {
                Application currentApp = appRepo.GetApplicationByID(idvm.ApplicationID);

                //Process all data that is in the view model. If anything is new or changed,
                //update the coaches current application.
                var uploads = Path.Combine(_environment.WebRootPath, "Images", "ID");
                try
                {
                    if (idvm.File.Length > 0)
                    {
                        using (var fileStream = new FileStream(Path.Combine(uploads, idvm.ApplicationID.ToString() + ".jpg"), FileMode.Create))
                        {
                            await idvm.File.CopyToAsync(fileStream);
                            currentApp.DlPath = "..\\Images\\ID\\" + currentApp.ApplicationID.ToString() + ".jpg";
                        }
                    }
                }
                catch (Exception e)
                {

                }
                appRepo.Update(currentApp);

                #region App Status
                ApplicationStatus appStatus = appStatusRepo.GetAppStatusByID(currentApp.ApplicationID);

                if ((appStatus.IdSubmissionDate == null ||
                    appStatus.IdSubmissionDate == new DateTime()) &&
                    currentApp.DlPath != null)
                {
                    appStatus.IdSubmissionDate = DateTime.Now;
                    appStatusRepo.Update(appStatus);
                }
                #endregion

                //Decide which direction is being taken.
                if (idvm.Direction == "approve")
                {
                    if (appStatus.IdApprovalDate == null || appStatus.IdApprovalDate == new DateTime())
                        appStatus.IdApprovalDate = DateTime.Now;
                    if (appStatus.IdDenialDate != null || appStatus.IdDenialDate != new DateTime())
                        appStatus.IdDenialDate = null;

                    appStatusRepo.Update(appStatus);
                    return RedirectToAction("Badge", new { AppID = idvm.ApplicationID });
                }

                if (idvm.Direction == "deny")
                {
                    if (appStatus.IdDenialDate == null || appStatus.IdDenialDate == new DateTime())
                    {
                        appStatus.IdDenialDate = DateTime.Now;
                        if (appStatus.IdApprovalDate != null && appStatus.IdApprovalDate != new DateTime())
                            appStatus.IdApprovalDate = null;

                        appStatusRepo.Update(appStatus);
                    }

                    User appuser = userRepo.GetUserByID(idvm.ApplicationID);
                    return RedirectToAction("ApplicantDetails", new { ApplicantID = appuser.Id });
                }
                if (idvm.Direction == "previous")
                {
                    if (currentApp.IsHeadCoach == true)
                        return RedirectToAction("PcaCourse", new { AppID = idvm.ApplicationID });
                    else
                        return RedirectToAction("ConcussionCourse", new { AppID = idvm.ApplicationID });
                }
                if (idvm.Direction == "next")
                    return RedirectToAction("Badge", new { AppID = idvm.ApplicationID });

                //if all else fails, post back to the same page.
                return View(idvm);
            }
            else
                return RedirectToAction("AccessDenied", "Account");
        }
        #endregion

        #region Application Badge
        [HttpGet]
        public async Task<IActionResult> Badge(int AppID)
        {
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                user = userRepo.GetDetailedUser(user);
            }

            //This will probably need to include all of your past application id's as well. so users can view their own past apps.
            if (User.IsInRole("Admin") || User.IsInRole("SportsManager") || user.currentYearApp.ApplicationID == AppID)
            {
                //Get the coaches current app
                Application currentApp = appRepo.GetApplicationByID(AppID);
                BadgeViewModel bvm = new BadgeViewModel();
                bvm.ApplicationID = AppID;
                //If any information exists, bind it to the view model.
                if (currentApp.BadgePath != null) bvm.BadgePath = currentApp.BadgePath; else bvm.BadgePath = "";

                //Display the view.
                return View(bvm);
            }
            else
                return RedirectToAction("AccessDenied", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Badge(BadgeViewModel bvm)
        {
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                user = userRepo.GetDetailedUser(user);
            }

            //This will probably need to include all of your past application id's as well. so users can view their own past apps.
            if (User.IsInRole("Admin") || User.IsInRole("SportsManager") || user.currentYearApp.ApplicationID == bvm.ApplicationID)
            {
                Application currentApp = appRepo.GetApplicationByID(bvm.ApplicationID);

                //Process all data that is in the view model. If anything is new or changed,
                //update the coaches current application.
                var uploads = Path.Combine(_environment.WebRootPath, "Images", "Badge");
                try
                {
                    if (bvm.File.Length > 0)
                    {
                        using (var fileStream = new FileStream(Path.Combine(uploads, bvm.ApplicationID.ToString() + ".jpg"), FileMode.Create))
                        {
                            await bvm.File.CopyToAsync(fileStream);
                            currentApp.BadgePath = "..\\Images\\Badge\\" + currentApp.ApplicationID.ToString() + ".jpg";
                        }
                    }
                }
                catch (Exception e)
                {

                }
                appRepo.Update(currentApp);

                #region App Status
                ApplicationStatus appStatus = appStatusRepo.GetAppStatusByID(currentApp.ApplicationID);

                if ((appStatus.BadgeSubmissionDate == null ||
                    appStatus.BadgeSubmissionDate == new DateTime()) &&
                    currentApp.BadgePath != null && currentApp.BadgePath != "")
                {
                    appStatus.BadgeSubmissionDate = DateTime.Now;
                    appStatusRepo.Update(appStatus);
                }
                #endregion

                //Decide which direction is being taken.
                if (bvm.Direction == "approve")
                {
                    if (appStatus.BadgeApprovalDate == null || appStatus.BadgeApprovalDate == new DateTime())
                        appStatus.BadgeApprovalDate = DateTime.Now;
                    if (appStatus.BadgeDenialDate != null || appStatus.BadgeDenialDate != new DateTime())
                        appStatus.BadgeDenialDate = null;

                    appStatusRepo.Update(appStatus);
                    User appuser = userRepo.GetUserByID(bvm.ApplicationID);
                    return RedirectToAction("ApplicantDetails", new { ApplicantID = appuser.Id });
                }

                if (bvm.Direction == "deny")
                {
                    if (appStatus.BadgeDenialDate == null || appStatus.BadgeDenialDate == new DateTime())
                    {
                        appStatus.BadgeDenialDate = DateTime.Now;
                        if (appStatus.BadgeApprovalDate != null && appStatus.BadgeApprovalDate != new DateTime())
                            appStatus.BadgeApprovalDate = null;

                        appStatusRepo.Update(appStatus);
                    }

                    User appuser = userRepo.GetUserByID(bvm.ApplicationID);
                    return RedirectToAction("ApplicantDetails", new { ApplicantID = appuser.Id });
                }
                if (bvm.Direction == "previous")
                    return RedirectToAction("ID", new { AppID = bvm.ApplicationID });
                //This is going to need to check if the user is an admin/sportsmanager since they have a different "index"
                if (bvm.Direction == "next")
                {
                    if (User.IsInRole("SportsManager") || User.IsInRole("Admin"))
                    {
                        User appuser = userRepo.GetUserByID(bvm.ApplicationID);
                        return RedirectToAction("ApplicantDetails", new { ApplicantID = appuser.Id });
                    }
                    return RedirectToAction("Index");
                }

                //if all else fails, post back to the same page.
                return View(bvm);
            }
            else
                return RedirectToAction("AccessDenied", "Account");
        }
        #endregion


    }
}