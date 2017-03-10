using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RedVentures.Host.Extensions;
using RedVentures.Host.Helpers;
using RedVentures.Host.Models;
using RedVentures.Host.Repository;

namespace RedVentures.Host.Controllers
{
    [Authorize]
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("users")]
        public HttpResponseMessage Users()
        {
            var values = DataRepository.GetUsers().ToBasicUser().Values.ToList();
            return HttpResponseHelper.CreateMessage(HttpStatusCode.OK, values.ToHttpContent());
        }

        [HttpGet]
        [Route("users/{id}")]
        public HttpResponseMessage Users(string id)
        {
            UserModelDetailed user;
            return !DataRepository.GetUsers().TryGetUser(id, out user)
                ? HttpResponseHelper.CreateMessage(HttpStatusCode.NotFound, "Not Found".ToHttpContent())
                : HttpResponseHelper.CreateMessage(HttpStatusCode.OK, user.ToHttpContent());
        }

        [HttpPut]
        [Route("users/{userId}/{widgetId}")]
        public HttpResponseMessage AddWidgetToUser(string userId, string widgetId)
        {
            UserModelDetailed user;
            WidgetModel widget;

            var userExists = DataRepository.GetUsers().TryGetUser(userId, out user);
            var widgetExists = DataRepository.GetWidgets().TryGetWidget(widgetId, out widget);

            return userExists && widgetExists
                ? LinkWidgetToUser(user, widget)
                : HttpResponseHelper.CreateMessage(HttpStatusCode.NotFound, "User/Widget Not Found".ToHttpContent());
        }

        [HttpGet]
        [Route("users/{userId}/{widgetId}")]
        public HttpResponseMessage GetUsersWidget(string userId, string widgetId)
        {
            UserModelDetailed user;

            int widgetIdParsed;

            var userExists = DataRepository.GetUsers().TryGetUser(userId, out user);

            if (!userExists || !int.TryParse(widgetId, out widgetIdParsed))
                return HttpResponseHelper.CreateMessage(HttpStatusCode.NotFound, "User Id/Widget Id was invalid".ToHttpContent());

            var widget = user.Widgets.FirstOrDefault(_ => _.Id == widgetIdParsed);

            return (widget == null)
                ? HttpResponseHelper.CreateMessage(HttpStatusCode.NotFound, "Not found matching User/Widget".ToHttpContent())
                : HttpResponseHelper.CreateMessage(HttpStatusCode.OK, widget.ToHttpContent());
        }

        private HttpResponseMessage LinkWidgetToUser(UserModelDetailed user, WidgetModel widget)
        {
            try
            {
                DataRepository.LinkWidgetToUser(user.Id, widget.Id);
                return HttpResponseHelper.CreateMessage(HttpStatusCode.OK, "Widget added".ToHttpContent());
            }
            catch (Exception ex)
            {
                return HttpResponseHelper.CreateMessage(HttpStatusCode.InternalServerError, ex.Message.ToHttpContent());
            }
        }
    }
}