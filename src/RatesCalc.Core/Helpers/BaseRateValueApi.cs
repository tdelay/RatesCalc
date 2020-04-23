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

        public async Task<string> GetAsync(Uri requestUrl)
        {
            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public XmlElement ParseXmlData(string body)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(body);
            return doc.DocumentElement;
        }

        public T ParseDataByType<T>(XmlElement element)
        {
            return (T)Convert.ChangeType(element.InnerText, typeof(T));
        }

        private Uri CreateRequestUri(string queryString = "")
        {
            var uri = new Uri(string.Format(BaseEndpoint + queryString));
            return uri;
        }

        public async Task<double> GetRates(string rateCode)
        {
            var requestUrl = CreateRequestUri(rateCode);
            var responseBody = await GetAsync(requestUrl);
            var xmlElement = ParseXmlData(responseBody);
            return ParseDataByType<double>(xmlElement);
        }

    }
}
