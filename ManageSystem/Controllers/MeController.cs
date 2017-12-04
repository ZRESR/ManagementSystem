using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ManageSystem.Controllers
{
    public class MeController : ApiController
    {
        public class LoginModel
        {
            public string username { set; get; }
            public string password { set; get; }
        }
        // GET: api/Me
        public JsonResult Get()
        {
            var type = Request.Headers.GetValues("type").First().ToString();
            var result = new JsonResult();
            if (type == "student")
            {
                var me = new { id = 1, type = "student", name = "张三", number = "24320152202333", phone = "18911114514", email = "24320152202333@stu.xmu.edu.cn", gender = "male", school = new { id = 32, name = "厦门大学" }, title = "", avatar = "../../images/user.png" };
                result.Data = me;
            }
            else
            {
                var me = new { id = 2, type = "teacher", name = "邱明", number = "1121432543", phone = "18987965721", email = "1121432543@xmu.edu.cn", gender = "male", school = new { id = 32, name = "厦门大学" }, title = "", avatar = "../../images/user.png" };
                result.Data = me;
            }
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        // GET: api/Me/5
        public string Get(int id)
        {
            return "value";
        }
        // POST: api/Me
        public void POST([FromBody]dynamic json)
        {

        }
        // POST: api/signin
        [System.Web.Http.Route("api/signin")]
        [System.Web.Http.HttpPost]
        public JsonResult Login([FromBody]dynamic json) 
        {
            JsonResult result = new JsonResult();
            var student = new { id = 3486, type = "student", name = "张三" };
            var teacher = new { id = 4532, type = "teacher", name = "邱明" };
            var failed = false;
            string a = json.username;
            string b = json.password;
            if (a == "18911114514" && b == "qwer2345!")
                result.Data = student;
            else if (a == "18911118978" && b == "asdf1234!")
                result.Data = teacher;
            else result.Data = failed;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        // PUT: api/Me/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Me/5
        public void Delete(int id)
        {
        }
    }
}
