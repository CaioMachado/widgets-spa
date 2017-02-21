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
    public class WidgetsController : ApiController
    {
        private static int _lastId = 2;

        private static readonly Dictionary<int, WidgetModel> DicWidgets = new Dictionary<int, WidgetModel>
        {
            {1, WidgetModel.Create(1, "update success", "black", 1111.00, 122, true) },
            {2, WidgetModel.Create(1, "Vice President", "magenta", 3.80, 23, true) }
        };

        [Authorize]
        [HttpGet]
        [Route("widgets")]
        public HttpResponseMessage Widgets()
        {
            var values = DicWidgets.Values.ToList();
            return HttpResponseHelper.CreateMessage(HttpStatusCode.OK, values.ToHttpContent());
        }

        [Authorize]
        [HttpGet]
        [Route("widgets/{id}")]
        public HttpResponseMessage Widgets(string id)
        {
            int idParsed;
            WidgetModel widget;
            return !int.TryParse(id, out idParsed) || !DicWidgets.TryGetValue(idParsed, out widget)
                ? HttpResponseHelper.CreateMessage(HttpStatusCode.NotFound, "false".ToHttpContent())
                : HttpResponseHelper.CreateMessage(HttpStatusCode.OK, widget.ToHttpContent());
        }

        [Authorize]
        [HttpPost]
        [Route("widgets")]
        public HttpResponseMessage Widgets([FromBody]WidgetModel widget)
        {
            if (widget == null)
                return HttpResponseHelper.CreateMessage(HttpStatusCode.BadRequest, "Bad Request".ToHttpContent());

            _lastId++;
            widget.Id = _lastId;
            DicWidgets.Add(widget.Id, widget);
            return HttpResponseHelper.CreateMessage(HttpStatusCode.Created, "added!".ToHttpContent());
        }

        [Authorize]
        [HttpPut]
        [Route("widgets/{id}")]
        public HttpResponseMessage Widgets(string id, [FromBody]WidgetModel widget)
        {
            if (widget == null)
                return HttpResponseHelper.CreateMessage(HttpStatusCode.BadRequest, "Bad Request".ToHttpContent());

            int idParsed;
            if (!int.TryParse(id, out idParsed) || !DicWidgets.ContainsKey(idParsed))
                return HttpResponseHelper.CreateMessage(HttpStatusCode.NotFound, "widget not found".ToHttpContent());

            widget.Id = idParsed;
            DicWidgets[idParsed] = widget;

            return HttpResponseHelper.CreateMessage(HttpStatusCode.NoContent);
        }
    }
}