namespace ClinicAPI.Exceptions
{
    public class NoEntitiesFoundException : Exception
    {
        string message;
        public NoEntitiesFoundException()
        {
            message = "No entities found";
        }
        public NoEntitiesFoundException(string message) : base(message)
        {
            this.message = message;
        }
        public override string Message => message;
    }
}
