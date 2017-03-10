using RedVentures.Host.Repository;
using System.Collections.Generic;

namespace RedVentures.Host.Helpers
{
    public class LoginAuthenticator
    {
        public static bool Authenticate(string userName, string password)
        {
            string value;
            var login = DataRepository.GetLogins();
            return login.TryGetValue(userName, out value) && value == password;
        }
    }
}
