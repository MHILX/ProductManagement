using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace ProductManagement.Test
{
    public class ApiIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        // private readonly HttpClient _client;
        private readonly WebApplicationFactory<Program> _factory;

        public ApiIntegrationTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            //_client = factory.CreateClient(new WebApplicationFactoryClientOptions
            //{
            //    AllowAutoRedirect = false
            //});
        }

        [Fact(Skip = "Skipping this test for now")]
        public async Task Get_Products_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();
            var request = "/api/products";

            // Act
            var response = await client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseString);
        }
    }
}
