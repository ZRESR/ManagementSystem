﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Class
        public ActionResult ClassManage()
        {
            return View();
        }
        public ActionResult StudentRollCallUI()
        {
            return View();
        }
        public ActionResult RandomGroupChooseTopicUI2()
        {
            return View();
        }
    }
}