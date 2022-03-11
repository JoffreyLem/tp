using System.Net.Http;
using Xunit;

namespace Tournaments.Tests.Utils
{
    public class BaseTest : IClassFixture<ClientUtils>
    {
        public HttpClient Client { get; set; }
        private ClientUtils _client;

        public BaseTest(ClientUtils client)
        {
            this._client = client;
            Client = client.Client;

        }

      
    }
}