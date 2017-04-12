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

        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Page4()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Page4(Page4ViewModel p4Vm)
        {
            Application app = new Application();
            var uploads = Path.Combine(_environment.WebRootPath);
            if (p4Vm.File.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, p4Vm.File.FileName), FileMode.Create))
                {
                    await p4Vm.File.CopyToAsync(fileStream);
                }
                app.NfhsPath = $"\\{p4Vm.File.FileName}";
                return RedirectToAction("Page5", "Account");
            }
            return View(p4Vm);
        }
        [HttpGet]
        public IActionResult Page5()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Page5(Page5ViewModel p5Vm)
        {
            Application app = new Application();
            var uploads = Path.Combine(_environment.WebRootPath);
            if (p5Vm.File.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, p5Vm.File.FileName), FileMode.Create))
                {
                    await p5Vm.File.CopyToAsync(fileStream);
                }
                app.PcaPath = $"\\{p5Vm.File.FileName}";
                return RedirectToAction("Page6", "Account");
            }
            return View(p5Vm);
        }
        [HttpGet]
        public IActionResult Page6()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Page6(Page6ViewModel p6Vm)
        {
            Application app = new Application();
            var uploads = Path.Combine(_environment.WebRootPath);
            if (p6Vm.File.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, p6Vm.File.FileName), FileMode.Create))
                {
                    await p6Vm.File.CopyToAsync(fileStream);
                }
                app.DlPath = $"\\{p6Vm.File.FileName}";
                return RedirectToAction("Page7", "Account");
            }
            return View(p6Vm);
        }
        [HttpGet]
        public IActionResult Page7()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Page7(Page7ViewModel p7Vm)
        {
            Application app = new Application();
            var uploads = Path.Combine(_environment.WebRootPath);
            if (p7Vm.File.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, p7Vm.File.FileName), FileMode.Create))
                {
                    await p7Vm.File.CopyToAsync(fileStream);
                }
                app.DlPath = $"\\{p7Vm.File.FileName}";
                return RedirectToAction("Page7", "Account");
            }
            return View(p7Vm);
        }

       

    }
}
