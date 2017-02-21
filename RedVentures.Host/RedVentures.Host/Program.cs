using Microsoft.Owin.Hosting;
using System;

namespace RedVentures.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseUri = "http://localhost:8080";

            Console.WriteLine("Starting Web Server.");
            WebApp.Start<ApiStartup>(baseUri);
            Console.WriteLine("Server running at {0}.", baseUri);
            Console.ReadLine();
        }
    }
}
