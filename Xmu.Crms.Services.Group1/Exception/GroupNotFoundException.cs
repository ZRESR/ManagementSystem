namespace Xmu.Crms.Services.Group1.Exceptions
{
    public class GroupNotFoundException : System.Exception
    {
        private string message;
        public GroupNotFoundException()
        {
            message = "找不到该小组！";
        }
        public override string ToString()
        {
            return message;
        }
    }
}