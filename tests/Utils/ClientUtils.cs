using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tournaments.Tests.Utils
{
    public class ClientUtils
    {


        public static HttpClient GetClient()
        {
            var app = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("test");
            });
        
            return app.CreateClient();
        }
    }
}