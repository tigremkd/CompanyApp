namespace WebApi.Utility.Exceptions
{
    public class InnerException : Exception
    {


        public InnerException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
