using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using KidSports.ViewModels;
using KidSports.Models;

namespace KidSports.Controllers
{
    public class Account : Controller
    {
        

        public IActionResult Login()
        {
            return View();
        }
        
       

    }
}
