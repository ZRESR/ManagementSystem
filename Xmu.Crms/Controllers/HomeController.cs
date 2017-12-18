using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Xmu.Crms.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public IActionResult ChooseCharacter()
        {
            return View();
        }
        public IActionResult ChooseSchool()
        {
            return View();
        }
        public IActionResult LoginUI()
        {
            return View();
        }
        public IActionResult RegisterUI()
        {
            return View();
        }
    }
}