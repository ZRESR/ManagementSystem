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
    public class ClassController : ApiController
    {
        //GET api/class/{classId}
        [System.Web.Http.Route("api/class/{classid}")]
        [System.Web.Http.HttpGet]
        public JsonResult getClassById(int classid)
        {
            JsonResult result = new JsonResult();
            var Class1 = new { id = 1, name = "周三1-2节", numstudent = 54, time = "周三 一二节", calling = true, roster = "", proportions = new { a = 20, b = 60, c = 20, report = 50, presentation = 50 } };
            var Class2 = new { id = 2, name = "周三3-4节", numstudent = 65, time = "周三 三四节", calling = true, roster = "", proportions = new { a = 20, b = 60, c = 20, report = 50, presentation = 50 } };
            var Class3 = new { id = 3, name = "周二7-8节", numstudent = 34, time = "周二 七八节", calling = true, roster = "", proportions = new { a = 20, b = 60, c = 20, report = 50, presentation = 50 } };
            var Class4 = new { id = 4, name = "周四7-8节", numstudent = 70, time = "周四 七八节", calling = true, roster = "", proportions = new { a = 20, b = 60, c = 20, report = 50, presentation = 50 } };
            if (classid==1)
                result.Data = Class1;
            else if(classid == 2)
                result.Data = Class2;
            else if (classid == 3)
                result.Data = Class3;
            else if (classid == 4)
                result.Data = Class4;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        //GET api/class/{classId}
        [System.Web.Http.Route("api/class/{classid}/attendance")]
        [System.Web.Http.HttpGet]
        public JsonResult getAttendanceById(int classid)
        {
            var showLate = Request.Headers.GetValues("showLate").First().ToString();
            JsonResult result = new JsonResult();
            var students = new { numPresent = 4, present = new object[]{ new { id = 2537, name = "张三" }, new { id = 8232, name = "李四" }, new { id = 3245, name = "王五" }, new { id = 1234, name = "赵六" } } };
            var students2 = new { numPresent = 4, present = new object[] { new { id = 2537, name = "张三" }, new { id = 8232, name = "李四" }, new { id = 3245, name = "王五" }, new { id = 1234, name = "赵六" } }, late = new object[] { new { id = 4543, name = "张明" }, new { id = 2563, name = "李强" } } };
            if (showLate == "false")
                result.Data = students;
            else
                result.Data = students2;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}