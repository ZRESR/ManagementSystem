using System;

namespace Xmu.Crms.Services.Group1.Exceptions
{
    public class PasswordErrorException : Exception
    {
        private string message;
        public PasswordErrorException()
        {
            message = "密码输入错误，请重新输入！";
        }
        public override string ToString()
        {
            return message;
        }
    }
}
