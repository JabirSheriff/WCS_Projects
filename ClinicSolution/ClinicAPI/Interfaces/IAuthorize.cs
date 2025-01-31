namespace ClinicAPI.Interfaces
{
    public interface IAuthorize<T,K> where K : class
    {
        Task<K> Login(string email, string password);
    }
}
