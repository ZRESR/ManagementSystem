namespace Xmu.Crms.Services.Group1.Exceptions
{
    public class TopicNotFoundException : System.Exception
    {
        private string message;
        public TopicNotFoundException()
        {
            message = "找不到该讨论课！";
        }
        public override string ToString()
        {
            return message;
        }
    }
}