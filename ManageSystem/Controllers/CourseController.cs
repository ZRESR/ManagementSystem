using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Mvc;
using Newtonsoft.Json;
using Microsoft.CSharp;

namespace ManageSystem.Controllers
{
    public class CourseController : ApiController
    {
        // GET: api/Course
        public JsonResult Get()
        {
            var type = Request.Headers.GetValues("type").First().ToString();
            if (type == "teacher")
            {
                var courses = new object[] { new { id = 1, name = "OOAD", description = "面向对象设计与分析" }, new { id = 2, name = "J2EE", description = "J2EE" } };
                var result = new JsonResult();
                result.Data = courses;
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return result;
            }
            else
            {
                var result = new JsonResult();
                var courses = new object[] { new { id = 1, name = "OOAD", teacher = "邱明",description = "面向对象设计与分析" },
                new { id = 2, name = "J2EE", teacher = "邱明", description = "J2EE" },
                new { id = 3, name = "操作系统", teacher = "吴清强", description = "操作系统" },
                new { id = 4, name = "数据仓库", teacher = "王鸿吉", description = "数据仓库" } };
                result.Data = courses;
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return result;

            }
        }
        // GET: api/Course/5
        public JsonResult Get(int id)
        {
            var result = new JsonResult();
            if (id == 1)
            {
                var course = new { id = 1, name = "OOAD", teacher = "邱明", teacherEmail = "mingqiu@xmu.edu.cn", description = "面向对象设计与分析" };
                result.Data = course;
            }
            else if(id == 2)
            {
                var course = new { id = 2, name = "J2EE", teacher = "邱明", teacherEmail = "mingqiu@xmu.edu.cn", description = "J2EE" };
                result.Data = course;
            }
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        // GET: api/Course/{id}/Seminar
        [System.Web.Http.Route("api/course/{id}/seminar")]
        [System.Web.Http.HttpGet]
        public JsonResult getSeminar(int id)
        {
            JsonResult result = new JsonResult();
            if (id == 1)
            {
                var seminars = new object[] { new { id = 1,name = "界面原型设计", description = "界面原型设计",
        groupingMethod = "fixed", startTime = "9月25日", endTime = "10月9日" },
                    new { id = 2,name = "概要设计", description = "模型层与数据库设计",
        groupingMethod = "random", startTime = "10月10日", endTime = "10月24日" }
                };
                result.Data = seminars;
            }
            else if(id == 2)
            {
                var seminars = new object[] { new { id = 1,name = "包划分", description = "包划分",
        groupingMethod = "random", startTime = "9月25日", endTime = "10月9日" },
                    new { id = 2,name = "概要设计", description = "模型层与数据库设计",
        groupingMethod = "random", startTime = "10月10日", endTime = "10月24日" }
                };
                result.Data = seminars;
            }
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        //GET: api/course/{courseId}/class
        [System.Web.Http.Route("api/course/{courseId}/class")]
        [System.Web.Http.HttpGet]
        public JsonResult getClassByCourseId(int courseId)
        {
            JsonResult result = new JsonResult();
            var Class = new object[] { new { id = 1, name = "周三1-2节" }, new { id = 2, name = "周三3-4节" } };
            var Class2 = new object[] { new { id = 3, name = "周二7-8节" }, new { id = 4, name = "周四7-8节" } };
            if (courseId == 1)
                result.Data = Class;
            else if (courseId == 2)
                result.Data = Class2;
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
