using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tournaments.Tests.Utils
{
    public class ClientUtils
    {
        public  HttpClient Client { get; set; }
        public ClientUtils()
        {
            var app = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("test");
            });
           Client = app.CreateClient();
        }





     
    }
}