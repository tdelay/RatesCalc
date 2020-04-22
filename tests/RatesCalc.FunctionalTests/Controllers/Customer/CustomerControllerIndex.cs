using RatesCalc.Web;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RatesCalc.FunctionalTests.Controllers
{
    public class CustomerControllerIndex : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public CustomerControllerIndex(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsViewWithCorrectMessage()
        {
            HttpResponseMessage response = await _client.GetAsync("/Customer");
            response.EnsureSuccessStatusCode();
            string stringResponse = await response.Content.ReadAsStringAsync();

            Assert.Contains("RatesCalc.Web", stringResponse);
        }

        [Fact]
        public async Task ReturnsViewWCustomerById()
        {
            var cutomerId = 1;
            HttpResponseMessage response = await _client.GetAsync("/Customer/Details/" + cutomerId);
            response.EnsureSuccessStatusCode();
            string stringResponse = await response.Content.ReadAsStringAsync();
            Assert.Contains("RatesCalc.Web", stringResponse);
        }
    }
}
