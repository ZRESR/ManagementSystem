namespace Xmu.Crms.Services.Group1.Exceptions
{
    public class ClassNotFoundException : System.Exception
    {
        private string message;
        public ClassNotFoundException()
        {
            message = "找不到该班级！";
        }
        public override string ToString() 
        {
            return message;
        }
    }
}