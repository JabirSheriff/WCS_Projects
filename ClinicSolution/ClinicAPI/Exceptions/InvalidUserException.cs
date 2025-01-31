namespace ClinicAPI.Exceptions
{
    public class InvalidUserException : Exception
    {
        string message;
        public InvalidUserException()
        {
            message = "Invalid username or password";
        }
        public InvalidUserException(string message) : base(message)
        {
            this.message = message;
        }
        public override string Message => message;
    }
}
