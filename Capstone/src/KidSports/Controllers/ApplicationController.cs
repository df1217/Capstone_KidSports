using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using KidSports.Models.ViewModels;
using KidSports.Models;

namespace KidSports.Controllers
{
    public class ApplicationController : Controller
    {
        private IHostingEnvironment _environment;

        public ApplicationController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        #region Home Page
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NoApplication()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Appinprocess()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CompletedApplication()
        {
            return View();
        }
        #endregion

        #region SportsManager Views
        [HttpGet]
        public IActionResult Applications()
        {
            return View();
        }

        [HttpGet]
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

        #region Application Step 1
        [HttpGet]
        public IActionResult Page1()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Page1()
        //{
        //    return View();
        //}
        #endregion

        #region Application Step 2
        [HttpGet]
        public IActionResult Page2()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Page2()
        //{
        //    return View();
        //}
        #endregion

        #region Application Step 3
        [HttpGet]
        public IActionResult Page3()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Page3()
        //{
        //    return View();
        //}
        #endregion

        #region Application Step 4
        [HttpGet]
        public IActionResult Page4()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Page4(Page4ViewModel p4Vm)
        {
            var uploads = Path.Combine(_environment.WebRootPath);
            if (p4Vm.File.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, p4Vm.File.FileName), FileMode.Create))
                {
                    await p4Vm.File.CopyToAsync(fileStream);
                }
                //p4Vm.Application.NfhsPath = $"\\{p4Vm.File.FileName}";
                return RedirectToAction("Page5", "Application");
            }
            return View(p4Vm);
        }
        #endregion

        #region Application Step 5
        [HttpGet]
        public IActionResult Page5()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Page5(Page5ViewModel p5Vm)
        {
            var uploads = Path.Combine(_environment.WebRootPath);
            if (p5Vm.File.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, p5Vm.File.FileName), FileMode.Create))
                {
                    await p5Vm.File.CopyToAsync(fileStream);
                }
                //p5Vm.Application.PcaPath = $"\\{p5Vm.File.FileName}";
                return RedirectToAction("Page6", "Application");
            }
            return View(p5Vm);
        }
        #endregion

        #region Application Step 6
        [HttpGet]
        public IActionResult Page6()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Page6(Page6ViewModel p6Vm)
        {
            var uploads = Path.Combine(_environment.WebRootPath);
            if (p6Vm.File.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, p6Vm.File.FileName), FileMode.Create))
                {
                    await p6Vm.File.CopyToAsync(fileStream);
                }
                //p6Vm.Application.DlPath = $"\\{p6Vm.File.FileName}";
                return RedirectToAction("Page7", "Application");
            }
            return View(p6Vm);
        }
        #endregion

        #region Application Step 7
        [HttpGet]
        public IActionResult Page7()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Page7(Page7ViewModel p7Vm)
        {
            var uploads = Path.Combine(_environment.WebRootPath);
            if (p7Vm.File.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, p7Vm.File.FileName), FileMode.Create))
                {
                    await p7Vm.File.CopyToAsync(fileStream);
                }
                //p7Vm.Application.DlPath = $"\\{p7Vm.File.FileName}";
                return RedirectToAction("Page7", "Application");
            }
            return View(p7Vm);
        }
        #endregion

    }
}
