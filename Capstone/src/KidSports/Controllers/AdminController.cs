using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KidSports.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult UpdateAppContent()
        {
            return View();
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
