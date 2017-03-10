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
    public class WidgetsController : ApiController
    {
        private static int _lastId = 2;

        [HttpGet]
        [Route("widgets")]
        public HttpResponseMessage Widgets()
        {
            var values = DataRepository.GetWidgets().Values.ToList();
            return HttpResponseHelper.CreateMessage(HttpStatusCode.OK, values.ToHttpContent());
        }

        [HttpGet]
        [Route("widgets/{id}")]
        public HttpResponseMessage Widgets(string id)
        {
            WidgetModel widget;
            return !DataRepository.GetWidgets().TryGetWidget(id, out widget)
                ? HttpResponseHelper.CreateMessage(HttpStatusCode.NotFound, "false".ToHttpContent())
                : HttpResponseHelper.CreateMessage(HttpStatusCode.OK, widget.ToHttpContent());
        }

        [HttpPost]
        [Route("widgets")]
        public HttpResponseMessage Widgets([FromBody]WidgetModel widget)
        {
            if (widget == null)
                return HttpResponseHelper.CreateMessage(HttpStatusCode.BadRequest, "Bad Request".ToHttpContent());

            _lastId++;
            widget.Id = _lastId;
            DataRepository.AddWidget(widget.Id, widget);
            return HttpResponseHelper.CreateMessage(HttpStatusCode.Created, "added!".ToHttpContent());
        }

        [HttpPut]
        [Route("widgets/{id}")]
        public HttpResponseMessage Widgets(string id, [FromBody]WidgetModel widget)
        {
            if (widget == null)
                return HttpResponseHelper.CreateMessage(HttpStatusCode.BadRequest, "Bad Request".ToHttpContent());

            int idParsed;
            if (!int.TryParse(id, out idParsed) || !DataRepository.GetWidgets().ContainsKey(idParsed))
                return HttpResponseHelper.CreateMessage(HttpStatusCode.NotFound, "widget not found".ToHttpContent());

            widget.Id = idParsed;
            DataRepository.GetWidgets()[idParsed] = widget;

            return HttpResponseHelper.CreateMessage(HttpStatusCode.NoContent);
        }
    }
}