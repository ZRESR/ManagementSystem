using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ManageSystem.Controllers
{
    public class SchoolController : ApiController
    {
        // GET: api/School
        public JsonResult Get()
        {
            var courses = new object[] { new { id = 1, name = "厦门大学" }, new { id = 2, name = "厦门理工" }, new { id = 3, name = "嘉庚学院" } };
            var result = new JsonResult();
            result.Data = courses;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        // GET: api/School/5
        public JsonResult Get(int id)
        {
            var result = new JsonResult();
            if (id == 11)
            {
                var courses = new object[] { new { id = 111, name = "厦门大学" }, new { id = 112, name = "集美大学" }, new { id = 113, name = "厦门理工" } };
                result.Data = courses;
            }
            else if (id == 12)
            {
                var courses = new object[] { new { id = 121, name = "福州大学" }, new { id = 122, name = "福建师范大学" }, new { id = 123, name = "福建农林大学" } };
                result.Data = courses;
            }
            else if (id == 13)
            {
                var courses = new object[] { new { id = 131, name = "华侨大学" }, new { id = 132, name = "泉州师范大学" }, new { id = 133, name = "泉州理工" } };
                result.Data = courses;
            }
            else if (id == 21)
            {
                var courses = new object[] { new { id = 211, name = "中山大学" }, new { id = 212, name = "华南理工" }, new { id = 213, name = "暨南大学" } };
                result.Data = courses;
            }
            else if (id == 22)
            {
                var courses = new object[] { new { id = 221, name = "汕头大学" } };
                result.Data = courses;
            }
            else if (id == 23)
            {
                var courses = new object[] { new { id = 231, name = "深圳大学" }, new { id = 232, name = "南方科技大学" } };
                result.Data = courses;
            }
            else if (id == 31)
            {
                var courses = new object[] { new { id = 311, name = "广西大学" }, new { id = 312, name = "广西民族大学" }, new { id = 313, name = "广西医科大学" } };
                result.Data = courses;
            }
            else if (id == 32)
            {
                var courses = new object[] { new { id = 321, name = "广西科技大学" } };
                result.Data = courses;
            }
            else if (id == 33)
            {
                var courses = new object[] { new { id = 331, name = "广西师范大学" }, new { id = 332, name = "桂林理工大学" }, new { id = 333, name = "电子科技大学" } };
                result.Data = courses;
            }
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        // POST: api/School
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/School/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/School/5
        public void Delete(int id)
        {
        }
    }
}
