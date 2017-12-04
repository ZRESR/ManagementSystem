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
    public class GroupController : ApiController
    {
        //GET: api/group/{groupid}
        [System.Web.Http.Route("api/group/{id}")]
        [System.Web.Http.HttpGet]
        public JsonResult getGroupById(int id)
        {
            JsonResult result = new JsonResult();
            var group1 = new { id = 1, leader = new { id = 8888, name = "张三" }, members = new object[] { new { id = 5324, name = "李四" }, new { id = 5678, name = "王五" } },topics = new { id = 257, name = "领域模型" },report="" };
            var group2= new { id = 2, leader = new { id = 3423, name = "李明" }, members = new object[] { new { id = 3423, name = "张勇" }, new { id = 2353, name = "赵东" } }, topics = new { id = 257, name = "领域模型" }, report = "" };
            var group3 = new
            {
                id = 3,
                leader = new { id = 1823, name = "于和", number = "24320xxxxxx" },
                members = new object[] {
                            new { id = 2224, name = "周让", number = "24320xxxxxx" },
                            new { id = 1578, name = "吴取", number = "24320xxxxxx" },
                            new { id = 4124, name = "孟茶", number = "24320xxxxxx" }
                        },
                topics = new { id = 275, name = "界面设计" }
            };
            if (id == 1)
                result.Data = group1;
            else if(id == 2)
                result.Data = group2;
            else
                result.Data = group3;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        // GET: api/Group
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Group/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Group
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Group/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Group/5
        public void Delete(int id)
        {
        }
    }
}
