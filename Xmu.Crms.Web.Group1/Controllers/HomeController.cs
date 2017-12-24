using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Xmu.Crms.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment hostingEnvironment;
        public HomeController(IHostingEnvironment env)
        {
            this.hostingEnvironment = env;
        }
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
        public IActionResult Index()
        {
            ViewData["Message"] = "空";
            //var filename = "D://201291893228996";
            return View();
        }
        [HttpPost]
        public IActionResult Index(IList<IFormFile> files)
        {
            long size = 0;
            foreach (var file in files)
            {
                var filename = ContentDispositionHeaderValue
                        .Parse(file.ContentDisposition)
                        .FileName
                        .Trim('"');
                //这个hostingEnv.WebRootPath就是要存的地址可以改下
                filename = "D://es//ManagementSystem//Xmu.Crms.Web.Group1//wwwroot//uploads//" + $@"\{filename}";
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            ViewData["Message"] = $"{files.Count} file(s) /{ size}bytes uploaded successfully!";
            return View();
        }
    }
}