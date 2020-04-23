using RatesCalc.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Xunit;

namespace RatesCalc.IntegrationTests.Helpers
{
    public class BaseRateValueApiGetData
    {
        [Fact]
        public async void ReturnsAsyncDataFromApi ()
        {
            var rateValue = await BaseRateValueApiFactory.Instance.GetRates("VILIBOR3m");
            Assert.IsType<double>(rateValue);
        }  
        
        [Fact]
        public async void GetAsyncStringResponse()
        {
            var uri = new Uri("http://www.lb.lt/webservices/VilibidVilibor/VilibidVilibor.asmx/getLatestVilibRate?RateType=VILIBOR3m");
            var responseBOdy = await BaseRateValueApiFactory.Instance.GetAsync(uri);
            Assert.IsType<string>(responseBOdy);
        }  
        
        [Fact]
        public async void GetXmlElementFromResponseAndParseData()
        {
            var uri = new Uri("http://www.lb.lt/webservices/VilibidVilibor/VilibidVilibor.asmx/getLatestVilibRate?RateType=VILIBOR3m");
            var responseBOdy = await BaseRateValueApiFactory.Instance.GetAsync(uri);
            var xmlElement = BaseRateValueApiFactory.Instance.ParseXmlData(responseBOdy);
            var rateValue = BaseRateValueApiFactory.Instance.ParseDataByType<double>(xmlElement);
            Assert.IsType<XmlElement>(xmlElement);
            Assert.IsType<double>(rateValue);
        }

    }
}
