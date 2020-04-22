using RatesCalc.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace RatesCalc.IntegrationTests.Data
{
    public class EfRepositoryAdd : BaseEfRepoTest
    {
        [Fact]
        public void AddsItemAndSetsId()
        {
            var repository = GetRepository();
            var initialName = Guid.NewGuid().ToString();
            var item = new Customer
            {
                Name = initialName,
                HasAgreement = false
            };

            repository.Add(item);

            var newItem = repository.List<Customer>().FirstOrDefault();

            Assert.Equal(item, newItem);
            Assert.True(newItem?.Id > 0);
        }
    }
}
