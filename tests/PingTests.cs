using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Tournaments.Tests.Utils;
using Xunit;

namespace Tournaments.Tests
{
    public class PingTests
    {
       

        public PingTests(){
           
        }

        [Fact]
        public async Task Ping_Should_Return_200_OK()
        {
            var client = ClientUtils.GetClient(_factory);
            var response = await client.GetAsync("/api/ping");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        }
    }
}