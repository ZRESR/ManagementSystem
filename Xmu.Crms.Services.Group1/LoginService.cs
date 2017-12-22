using System;
using System.Linq;
using Xmu.Crms.Shared.Exceptions;
using Xmu.Crms.Shared.Models;
using Xmu.Crms.Shared.Service;

namespace Xmu.Crms.Services.Group1
{
    public class LoginService:ILoginService
    {
        private readonly CrmsContext _db;

        public LoginService(CrmsContext db)
        {
            _db = db;
        }

        public UserInfo SignInWeChat(long userId, string code, string state, string successUrl)
        {
            throw new NotImplementedException();
        }

        public UserInfo SignInPhone(UserInfo user)
        {
            var us = _db.UserInfo.SingleOrDefault(u => u.Phone == user.Phone);
            if (us == null)
            {
                throw new UserNotFoundException();
            }
            if (user.Password != us.Password) // 千万不要真的用明文存储密码！
            {
                throw new PasswordErrorException();
            }
            return us;
        }

        public UserInfo SignUpPhone(UserInfo user)
        {
            throw new NotImplementedException();
        }

        public void DeleteTeacherAccount(long userId)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudentAccount(long userId)
        {
            throw new NotImplementedException();
        }
    }
}
