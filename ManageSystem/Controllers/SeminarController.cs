using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using Microsoft.CSharp;//Dynamic Json
using System.Web;//HttpContext

namespace ManageSystem.Controllers
{
    public class SeminarController : ApiController
    {
        // GET: api/Seminar
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Seminar/5
        public JsonResult Get(int id)
        {
            var result = new JsonResult();
            if (id == 1)
            {
                var seminar = new { id = 1,name = "界面原型设计"};
                result.Data = seminar;
            }
            else if (id == 2)
            {
                var seminar = new { id = 1, name = "概要设计" };
                result.Data = seminar;
            }
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        // GET: api/Seminar/5/Group
        [System.Web.Http.Route("api/seminar/{id}/group")]
        [System.Web.Http.HttpGet]
        public JsonResult GetGroup(int id)
        {
            var result = new JsonResult();
            /*HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
            HttpRequestBase request = context.Request;//定义传统request对象
            string include = request.Params["include"];*/
            string gradeable = HttpContext.Current.Request.QueryString["gradeable"];
            string classid = HttpContext.Current.Request.QueryString["classid"];
            string include = HttpContext.Current.Request.QueryString["include"];
            if(gradeable != null)
            {
                var groups = new object[] {
                    new { id = 31, name = "A1" },
                    new { id = 32, name = "A2" },
                    new { id = 33, name = "A3" },
                    new { id = 34, name = "C1" },
                    new { id = 35, name = "C2" },
                    new { id = 36, name = "C3" }
                };
                result.Data = groups;
            }
            else
            {
                result.Data = new { status = "false" };
            }
            if(classid != null)
            {
                var groups = new object[]{ new { id = 1 }, new { id = 2 }, new { id = 3 } };
                /*new object[] {
                    new
                    {
                        id = 1,
                        leader = new { id = 8888, name = "张三", number = "24320xxxxxx" },
                        members = new object[] {
                            new { id = 5324, name = "李四", number = "24320xxxxxx" },
                            new { id = 5678, name = "王五", number = "24320xxxxxx" },
                            new { id = 5324, name = "赵六", number = "24320xxxxxx" }
                        },
                        topics = new { id = 257, name = "领域模型与模块" }
                    },
                    new
                    {
                        id = 2,
                        leader = new { id = 8123, name = "郑汉", number = "24320xxxxxx" },
                        members = new object[] {
                            new { id = 5224, name = "李甜", number = "24320xxxxxx" },
                            new { id = 5578, name = "刘毅", number = "24320xxxxxx" },
                            new { id = 5124, name = "关孟", number = "24320xxxxxx" }
                        },
                        topics = new { id = 27, name = "包设计" }
                    },
                    new
                    {
                        id = 3,
                        leader = new { id = 1823, name = "于和", number = "24320xxxxxx" },
                        members = new object[] {
                            new { id = 2224, name = "周让", number = "24320xxxxxx" },
                            new { id = 1578, name = "吴取", number = "24320xxxxxx" },
                            new { id = 4124, name = "孟茶", number = "24320xxxxxx" }
                        },
                        topics = new { id = 27, name = "领域模型设计" }
                    },
                };*/
                result.Data = groups;
            }
            if (include != null)
            {
                var group = new
                {
                    id = 1,
                    leader = new { id = 8888, name = "张三", number = "24320xxxxxx" },
                    members = new object[] {
                        new { id = 5324, name = "李四", number = "24320xxxxxx" },
                        new { id = 5678, name = "王五", number = "24320xxxxxx" },
                        new { id = 5324, name = "李四", number = "24320xxxxxx" }
                    },
                    topics = new { id = 257, name = "领域模型与模块" }
                };
                result.Data = group;
            }
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        [System.Web.Http.Route("api/Seminar/{id}/Topic")]
        [System.Web.Http.HttpGet]
        public JsonResult GetTopic(int id, HttpContext context)
        {
            var result = new JsonResult();
            var topics = new object[]
            {
                new { id = 257, name = "领域模型与模块", description = "Domain model与模块划分", groupLimit = 5, groupLeft = 2 },
                new { id = 258, name = "模块划分", description = "模块划分，PackageDiagram", groupLimit = 5, groupLeft = 1 },
                new { id = 259, name = "界面设计", description = "界面设计，界面原型设计", groupLimit = 5, groupLeft = 0 },
            };
            result.Data = topics;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        // POST: api/Seminar
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Seminar/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Seminar/5
        public void Delete(int id)
        {
        }
    }
}
