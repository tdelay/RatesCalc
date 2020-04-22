using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RatesCalc.Core.Helpers
{
    public class BaseRateValueApi
    {
        private readonly HttpClient _httpClient;
        private Uri BaseEndpoint { get; set; } = new Uri("http://www.lb.lt/webservices/VilibidVilibor/VilibidVilibor.asmx/getLatestVilibRate?RateType=");
        
        public BaseRateValueApi()
        {
            _httpClient = new HttpClient();
        } 
        
        public BaseRateValueApi(Uri baseEndpoint)
        {
            if (baseEndpoint == null)
            {
                throw new ArgumentNullException("baseEndpoint");
            }
            BaseEndpoint = baseEndpoint;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("text/xml"));
        }

        private async Task<T> GetAsync<T>(Uri requestUrl)
        {
            
            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var rate = ParseXmlData<T>(data);
            return rate;
        }

        private T ParseXmlData<T>(string body)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(body);
            XmlElement root = doc.DocumentElement;
            return (T)Convert.ChangeType(root.InnerText, typeof(T));
        }

        private Uri CreateRequestUri(string queryString = "")
        {
            var uri = new Uri(string.Format(BaseEndpoint + queryString));
            return uri;
        }

        public async Task<double> GetRates(string rateCode)
        {
            var requestUrl = CreateRequestUri(rateCode);
            return await GetAsync<double>(requestUrl);
        }

    }
}
