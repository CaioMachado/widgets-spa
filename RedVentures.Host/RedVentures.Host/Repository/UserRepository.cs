using System.Collections.Generic;

namespace RedVentures.Host.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Dictionary<string, string> _validUsers = new Dictionary<string, string>
        {
            {"redVentures", "redVentures!1" },
            {"administrator", "admin!@10" },
        };

        public bool Authenticate(string userName, string password)
        {
            string value;
            return _validUsers.TryGetValue(userName, out value) && value == password;
        }
    }
}