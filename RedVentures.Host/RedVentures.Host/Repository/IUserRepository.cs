namespace RedVentures.Host.Repository
{
    public interface IUserRepository
    {
        bool Authenticate(string userName, string password);
    }
}