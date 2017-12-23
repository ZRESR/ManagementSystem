namespace Xmu.Crms.Services.Group1.Exceptions
{
    public class SeminarNotFoundException : System.Exception
    {
        private string message;
        public SeminarNotFoundException()
        {
            message = "找不到该讨论课！";
        }
        public override string ToString()
        {
            return message;
        }
    }
}