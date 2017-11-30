using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ManageSystem.Controllers
{
    public class CityController : ApiController
    {
        // GET: api/City
        public JsonResult Get()
        {
            var courses = new object[] { new { id = 1, name = "泉州"}, new { id = 2, name = "福州"}, new { id = 3, name = "厦门" } };
            var result = new JsonResult();
            result.Data = courses;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        // GET: api/City/5
        public JsonResult Get(int id)
        {
            var result = new JsonResult();
            if (id == 1)
            {
                var courses = new object[] { new { id = 11, name = "厦门" }, new { id = 12, name = "福州" }, new { id = 13, name = "泉州" } };
                result.Data = courses;
            }
            else if(id == 2)
            {
                var courses = new object[] { new { id = 21, name = "广州" }, new { id = 22, name = "汕头" }, new { id = 23, name = "深圳" } };
                result.Data = courses;
            }
            else if (id == 3)
            {
                var courses = new object[] { new { id = 31, name = "南宁" }, new { id = 32, name = "柳州" }, new { id = 33, name = "桂林" } };
                result.Data = courses;
            }
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        // POST: api/City
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/City/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/City/5
        public void Delete(int id)
        {
        }
    }
}
