using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RedVentures.Host.Extensions;
using RedVentures.Host.Helpers;
using RedVentures.Host.Models;

namespace RedVentures.Host.Controllers
{
    public class UsersController : ApiController
    {
        private static readonly Dictionary<int, UserModel> DicUsers = new Dictionary<int, UserModel>
        {
            {1, UserModel.Create(1, "Colin", "http://www.gravatar.com/avatar/a51972ea936bc3b841350caef34ea47e?s=64&d=monsterid")},
            {2, UserModel.Create(2,"Kyle","http://www.gravatar.com/avatar/432f3e353c689fc37af86ae861d934f9?s=64&d=monsterid")},
            {3, UserModel.Create(3,"Thomas", "http://www.gravatar.com/avatar/48009c6a27d25ef0ea03f985d1f186b0?s=64&d=monsterid") }
        };

        [Authorize]
        [HttpGet]
        [Route("users")]
        public HttpResponseMessage Users()
        {
            var values = DicUsers.Values.ToList();
            return HttpResponseHelper.CreateMessage(HttpStatusCode.OK, values.ToHttpContent());
        }

        [Authorize]
        [HttpGet]
        [Route("users/{id}")]
        public HttpResponseMessage Users(string id)
        {
            int idParsed;
            UserModel user;
            return !int.TryParse(id, out idParsed) || !DicUsers.TryGetValue(idParsed, out user)
                ? HttpResponseHelper.CreateMessage(HttpStatusCode.NotFound, "Not Found".ToHttpContent())
                : HttpResponseHelper.CreateMessage(HttpStatusCode.OK, user.ToHttpContent());
        }
    }
}