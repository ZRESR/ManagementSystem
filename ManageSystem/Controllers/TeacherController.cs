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
        public ActionResult ClassManage()
        {
            return View();
        }
        public ActionResult TeacherMainUI()
        {
            return View();
        }
        public ActionResult GroupInfoUI2()
        {
            return View();
        }
        public ActionResult RollCallListUI()
        {
            return View();
        }
        public ActionResult FixedRollCallUI()
        {
            return View();
        }
        public ActionResult RandomRollCallUI()
        {
            return View();
        }
        public ActionResult TeacherBindingUI()
        {
            return View();
        }
    }
}