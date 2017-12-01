using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace ManageSystem.Controllers
{
    public class CourseController : ApiController
    {
        // GET: api/Course
        public JsonResult Get()
        {
            var courses = new object[] { new { id = 1, name = "OOAD", description = "面向对象设计与分析" },new { id = 2, name = "J2EE", description = "J2EE" } };
            var result = new JsonResult();
            result.Data = courses;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        // GET: api/Course/5
        public JsonResult Get(int id)
        {
            var course = new{ id = 1, name = "OOAD", description = "面向对象设计与分析" };
            var result = new JsonResult();
            result.Data = course;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        // POST: api/Course
        public JsonResult Post([FromBody]dynamic Json)
        {
            
            var course = new { id = Json.id, name = Json.name, status = "success" };
            var result = new JsonResult();
            result.Data = course;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        // PUT: api/Course/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Course/5
        public void Delete(int id)
        {
        }
    }
}
