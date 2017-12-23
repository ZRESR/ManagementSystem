namespace Xmu.Crms.Services.Group1.Exceptions
{
    public class UserNotFoundException : System.Exception
    {
        private string message;
        public UserNotFoundException()
        {
            message = "用户名不存在！";
        }
        public override string ToString()
        {
            return message;
        }
    }
}