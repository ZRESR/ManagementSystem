using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xmu.Crms.Shared.Service;

namespace Xmu.Crms.Controllers
{
    [Produces("application/json")]
    [Route("/api/group")]
    public class GroupController : Controller
    {
        private IGradeService gradeService;
        public GroupController(IGradeService gradeService)
        {
            this.gradeService = gradeService;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}/grade/presentation")]
        public IActionResult PostGrade(long id,[FromQuery]long topicId, [FromQuery]int grade)
        {
            var userId = long.Parse(User.Claims.Single(c => c.Type == "id").Value);
            gradeService.InsertGroupGradeByUserId(topicId, userId, id, grade);
            return Json(new { status = grade });
        }
    }
}
