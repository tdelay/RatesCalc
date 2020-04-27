using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using RatesCalc.WebService;
using RatesCalc.WebService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RatesCalc.FunctionalTests.ControllersApi.Customer
{
    public class CustomerController
    {
        private readonly HttpClient _client;

        public CustomerController()
        {
            var testServer = new TestServer(new Microsoft.AspNetCore.Hosting.WebHostBuilder()
                    .UseEnvironment("Development")
                    .UseStartup<Startup>());
            _client = testServer.CreateClient();
        }

        [Theory]
        [InlineData("GET")]
        public async Task ReturnsSeededItems(string method)
        {

            var request = new HttpRequestMessage(new HttpMethod(method), "api/GetAllCustomers");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<RatesCalc.Core.Data.Customer>>(stringResponse).ToList();

            Assert.Equal(2, result.Count());
        }

        [Theory]
        [InlineData("POST", 1, "VILIBOR6m")]
        public async Task CalclulateRates(string method, int agreementId, string baseRateCode)
        {
            DataForCalculateRatesApiDTO dataForCalculateRates = new DataForCalculateRatesApiDTO()
            {
                AgreementId = agreementId,
                BaseRateCode = baseRateCode
            };
            var jsonBody = JsonConvert.SerializeObject(dataForCalculateRates);
            HttpContent c = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(new HttpMethod(method), "api/CalculateInterestRate");
            request.Content = c;

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CalculatedInterestApiDTO>(stringResponse);
            Assert.IsType<CalculatedInterestApiDTO>(result);
        }
    }
}
