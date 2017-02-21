using System.Net.Http;
using System.Net.Http.Formatting;

namespace RedVentures.Host.Extensions
{
    public static class ObjectExtensions
    {
        public static HttpContent ToHttpContent(this object value)
        {
            return new ObjectContent(value.GetType(), value, new JsonMediaTypeFormatter());
        }
    }
}