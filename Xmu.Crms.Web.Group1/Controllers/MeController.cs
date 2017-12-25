using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Xmu.Crms.Shared.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Xmu.Crms.Shared.Service;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using System.IO;

namespace Xmu.Crms.Controllers
{
    [Produces("application/json")]
    [Route("/api")]
    public class MeController : Controller
    {
        private JwtSettings _jwtSettings;
        private IUserService userService;
        private IHostingEnvironment hostingEnvironment;
        public MeController(IHostingEnvironment env, IOptions<JwtSettings> _jwtSettingsAccesser, IUserService userService)
        {
            _jwtSettings = _jwtSettingsAccesser.Value;
            this.userService = userService;
            this.hostingEnvironment = env;
        }
        // GET: api/Me
        [Authorize]
        [HttpGet("me")]
        public IActionResult GetMe()
        {
            var temp = Request.Headers["Authorization"].ToString();
            var array = temp.Split(" ");
            var token = array[1];
            JwtSecurityToken jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var id = long.Parse(jwt.Claims.ElementAt(0).Value);
            var user = userService.GetUserByUserId(id);
            return Json(user);
        }
        [Authorize]
        [HttpPost("avatar")]
        public IActionResult PutAvatar([FromBody]dynamic json)
        {
            var temp = Request.Headers["Authorization"].ToString();
            var array = temp.Split(" ");
            var token = array[1];
            JwtSecurityToken jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var id = long.Parse(jwt.Claims.ElementAt(0).Value);
            UserInfo user = userService.GetUserByUserId(id);
            user.Avatar = json.path;
            userService.UpdateUserByUserId(id, user);
            return Json(new { status = json.path });
        }
        // PUT: api/Me/5
        [Authorize]
        [HttpPut("me")]
        public IActionResult Put()
        {
            var temp = Request.Headers["Authorization"].ToString();
            var array = temp.Split(" ");
            var token = array[1];
            JwtSecurityToken jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var id = long.Parse(jwt.Claims.ElementAt(0).Value);
            UserInfo user =  userService.GetUserByUserId(id);
            UserInfo newUser = new UserInfo
            {
                Id = user.Id,
                Phone = user.Phone,
                Password = user.Password
            };
            userService.UpdateUserByUserId(id, newUser);
            return Json(new { status = 200 });
        }
        
        // POST: api/signin
        [HttpPost("signin")]
        public JsonResult Login([FromBody]dynamic json) 
        {
            
            string a = json.username;
            string b = json.password;
            if (a == "18911114514" && b == "qwer2345!")
            {
                UserInfo user = userService.GetUserByUserId(3);
                var claims = new Claim[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, "student")
                };
                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.ServerSecretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    null,
                    null,
                    claims, 
                    DateTime.Now, DateTime.Now.AddMinutes(30),
                    creds);
                var t = token.Claims.ElementAt(1).Value;
                return Json(new { status="200", type = t, token = new JwtSecurityTokenHandler().WriteToken(token)});
            }
            else if (a == "18911118978" && b == "asdf1234!")
                return Json(" ");
            else return Json(new { status = "err" });
            

        }

    }
}
