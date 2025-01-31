namespace ClinicAPI.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        string message;
        public EntityNotFoundException()
        {
            message= "Entity not found";
        }
        public EntityNotFoundException(string message) : base(message)
        {
            this.message = message;
        }
        public override string Message => message;
    }
}
