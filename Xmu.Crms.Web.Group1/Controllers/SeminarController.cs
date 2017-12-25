using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Xmu.Crms.Shared.Service;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Xmu.Crms.Shared.Models;

namespace Xmu.Crms.Controllers
{
    [Produces("application/json")]
    [Route("/api/seminar")]
    public class SeminarController : Controller
    {
        private ISeminarGroupService seminarGroupService;
        private IFixGroupService fixGroupService;
        private ITopicService topicService;
        private ISeminarService seminarService;
        public SeminarController(ISeminarGroupService seminarGroupService, ITopicService topicService, ISeminarService seminarService, IFixGroupService fixGroupService)
        {
            this.seminarGroupService = seminarGroupService;
            this.fixGroupService = fixGroupService;
            this.topicService = topicService;
            this.seminarService = seminarService;
        }
        // GET: api/Seminar/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var seminar = seminarService.GetSeminarBySeminarId(id);
            return Json(seminar);
        }
        // GET: api/Seminar/5/Group
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}/group")]
        public IActionResult GetGroup(long id,[FromQuery]bool isFix, [FromQuery]bool gradeable, [FromQuery]long classid, [FromQuery]bool include)
        {
            var userId = long.Parse(User.Claims.Single(c => c.Type == "id").Value);
            if (gradeable)
            {
                var group = seminarGroupService.GetSeminarGroupById(id, userId);
                var groupTopics = topicService.ListSeminarGroupTopicByGroupId(group.Id);
                var allGroups = seminarGroupService.ListSeminarGroupBySeminarId(id);
                foreach(var g in allGroups)
                {
                }
                return Json(groupTopics);
            }
            if(classid != 0)
            {
                if (!isFix)
                {
                    var t = seminarGroupService.ListSeminarGroupBySeminarId(id);
                    List<SeminarGroup> groups = new List<SeminarGroup>();
                    foreach(var g in t)
                    {
                        if (g.ClassInfo.Id == classid) groups.Add(g);
                    }
                    return Json(groups);
                }
                else
                {
                    var groups = fixGroupService.ListFixGroupByClassId(classid);
                    return Json(groups);
                }
            }
            if (include)
            {
                var group = seminarGroupService.GetSeminarGroupById(id, userId);
                var members = seminarGroupService.ListSeminarGroupMemberByGroupId(group.Id);
                return Json(new { group = group, members = members });
            }
            else
                return Json(new{ status="false" });
        }
        [HttpGet("{id}/topic")]
        public IActionResult GetTopic(long id)
        {
            var topics = topicService.ListTopicBySeminarId(id);
            return Json(topics);
        }
    }
}
