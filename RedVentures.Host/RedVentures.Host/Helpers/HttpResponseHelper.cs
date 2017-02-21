using System.Net;
using System.Net.Http;

namespace RedVentures.Host.Helpers
{
    public static class HttpResponseHelper
    {
        public static HttpResponseMessage CreateMessage(HttpStatusCode statusCode, HttpContent content = null)
        {
            var response = new HttpResponseMessage(statusCode) { Content = content };
            return response;
        }
    }
}