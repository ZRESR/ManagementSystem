namespace Xmu.Crms.Services.Group1.Exceptions
{
    public class FixGroupNotFoundException : System.Exception
    {
        private string message;
        public FixGroupNotFoundException()
        {
            message = "找不到该固定小组！";
        }
        public override string ToString()
        {
            return message;
        }
    }
}