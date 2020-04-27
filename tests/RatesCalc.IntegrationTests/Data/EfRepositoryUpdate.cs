using Microsoft.EntityFrameworkCore;
using RatesCalc.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace RatesCalc.IntegrationTests.Data
{
    public class EfRepositoryUpdate : BaseEfRepoTest
    {
        [Fact]
        public void UpdatesItemAfterAddingIt()
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

            // detach the item so we get a different instance
            _dbContext.Entry(item).State = EntityState.Detached;

            // fetch the item and update its title
            var newItem = repository.List<Customer>()
                .FirstOrDefault(i => i.Name == initialName);
            Assert.NotNull(newItem);
            Assert.NotSame(item, newItem);
            var newName = Guid.NewGuid().ToString();
            newItem.Name = newName;

            // Update the item
            repository.Update(newItem);
            var updatedItem = repository.List<Customer>()
                .FirstOrDefault(i => i.Name == newName);

            Assert.NotNull(updatedItem);
            Assert.NotEqual(item.Name, updatedItem.Name);
            Assert.Equal(newItem.CustomerId, updatedItem.CustomerId);
        }

    }
}