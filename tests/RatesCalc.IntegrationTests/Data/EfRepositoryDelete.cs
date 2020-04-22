using RatesCalc.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RatesCalc.IntegrationTests.Data
{
    public class EfRepositoryDelete : BaseEfRepoTest
    {
        [Fact]
        public void DeletesItemAfterAddingIt()
        {
            // add an item
            var repository = GetRepository();
            var initialName = Guid.NewGuid().ToString();
            var item = new Customer
            {
                Name = initialName,
                HasAgreement = false
            };

            repository.Add(item);

            // delete the item
            repository.Delete(item);

            // verify it's no longer there
            Assert.DoesNotContain(repository.List<Customer>(),
                i => i.Name == initialName);
        }
    }
}
