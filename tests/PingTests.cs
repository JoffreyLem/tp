using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Tournaments.Tests.Utils;
using Xunit;

namespace Tournaments.Tests
{
    public class PingTests : IClassFixture<ClientUtils>
    {
        private ClientUtils _clientUtils;
        private HttpClient _client;
        public PingTests(ClientUtils clientUtils)
        {
            _clientUtils = clientUtils;
            _client = _clientUtils.Client;
        }

        [Fact]
        public async Task Ping_Should_Return_200_OK()
        {
          
            var response = await _client.GetAsync("/api/ping");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        }
    }
}