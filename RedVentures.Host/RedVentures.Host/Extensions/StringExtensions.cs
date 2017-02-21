using System.Net.Http;

namespace RedVentures.Host.Extensions
{
    public static class StringExtensions
    {
        public static HttpContent ToHttpContent(this string value)
        {
            return new StringContent(value);
        }
    }
}