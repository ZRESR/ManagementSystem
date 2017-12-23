namespace Xmu.Crms.Services.Group1.Exceptions
{
    public class CourseNotFoundException : System.Exception
    {
        private string message;
        public CourseNotFoundException()
        {
            message = "找不到该课程！";
        }
        public override string ToString()
        {
            return message;
        }
    }
}