using RatesCalc.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Xunit;

namespace RatesCalc.UnitTests.Core.Helpers
{
    public class BaseRateValueApics
    {

        [Fact]
        public void ReturnsCorectUri ()
        {
            string baseRateCode = "VILIBOR3m";
            var uri = BaseRateValueApiFactory.Instance.CreateRequestUri(baseRateCode);
            Assert.Contains(baseRateCode, uri.ToString());
            Assert.IsType<Uri>(uri);
        }
    }
}
