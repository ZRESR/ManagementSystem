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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Xmu.Crms.Shared.Exceptions;

namespace Xmu.Crms.Controllers
{
    [Produces("application/json")]
    [Route("/api")]
    public class MeController : Controller
    {
        private JwtSettings _jwtSettings;
        private IUserService userService;
        private ILoginService loginService;
        private IHostingEnvironment hostingEnvironment;
        public MeController(IHostingEnvironment env, IOptions<JwtSettings> _jwtSettingsAccesser, IUserService userService,ILoginService loginService)
        {
            _jwtSettings = _jwtSettingsAccesser.Value;
            this.userService = userService;
            this.hostingEnvironment = env;
            this.loginService = loginService;
        }


        //获取用户信息
        // GET: api/Me
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("me")]
        public IActionResult GetMe()
        {
            
            /*var temp = Request.Headers["Authorization"].ToString();
            var array = temp.Split(" ");
            var token = array[1];
            JwtSecurityToken jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);*/
            var id = long.Parse(User.Claims.Single(c => c.Type == "id").Value);
            var user = userService.GetUserByUserId(id);
            return Json(user);
        }


        //更换头像
        //POST: api/avatar
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("avatar")]
        public IActionResult PutAvatar([FromBody]dynamic json)
        {
            var id = long.Parse(User.Claims.Single(c => c.Type == "id").Value);
            UserInfo user = userService.GetUserByUserId(id);
            user.Avatar = json.path;
            userService.UpdateUserByUserId(id, user);
            return Json(new { status = json.path });
        }


        //解绑
        // PUT: api/unbind
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("unbind")]
        public IActionResult Put()
        {
            var id = long.Parse(User.Claims.Single(c => c.Type == "id").Value);
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

        //注册手机号和密码
        //POST: api/me
        [HttpPost("me")]
        public IActionResult Register([FromBody]dynamic json)
        {
            try
            {
                UserInfo userInfo = new UserInfo()
                {
                    Phone = json.phone,
                    Password = json.password
                };
                userInfo = loginService.SignUpPhone(userInfo);
                return Json(userInfo);
            }
            catch(ArgumentException e)
            {
                return Json(new { status = 1 });
            }
        }

        // POST: api/signin
        [HttpPost("signin")]
        public JsonResult Login([FromBody]dynamic json) 
        {
            try
            {

                UserInfo user = new UserInfo()
                {
                    Phone = json.username,
                    Password = json.password
                };
                user = loginService.SignInPhone(user);
                if(user.Type== Shared.Models.Type.Teacher)
                {
                    var claims = new Claim[]
                    {
                        new Claim("id", user.Id.ToString()),
                        new Claim("type", "teacher")
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
                    return Json(new { type = t, token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
                else if(user.Type==Shared.Models.Type.Student)
                {
                    var claims = new Claim[]
                    {
                        new Claim("id", user.Id.ToString()),
                        new Claim("type", "student")
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
                    return Json(new { type = t, token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
                else
                {
                    return Json(new { status = 500,id=user.Id});
                }
            }
            catch(PasswordErrorException e)
            {
                return Json(new { status = 404 });
            }
     
        }

    }
}
