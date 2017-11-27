using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageSystem.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult GroupInfoUI2()
        {
            return View();
        }
        public ActionResult RollCallListUI()
        {
            return View();
        }
        public ActionResult FixedRollStartCallUI()
        {
            return View();
        }
    }
}