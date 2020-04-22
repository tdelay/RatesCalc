using RatesCalc.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalc.Core.Factories
{
    public class BaseRateValueApiFactory
    {
        private static Lazy<BaseRateValueApi> apiClient = new Lazy<BaseRateValueApi>(
            () => new BaseRateValueApi(),
            System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

        public static BaseRateValueApi Instance
        {
            get
            {
                return apiClient.Value;
            }
        }
    }
}
