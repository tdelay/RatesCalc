using Microsoft.EntityFrameworkCore;
using RatesCalc.SharedBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RatesCalc.Core.Data;
using RatesCalc.SharedBase.Interfaces;

namespace RatesCalc.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Agreement> Agreements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
               .HasMany(c => c.Agreements)
               .WithOne(e => e.Customer);

            base.OnModelCreating(modelBuilder);

        }

        public async Task<int> SaveChangesAsync()
        {
            int result = await base.SaveChangesAsync().ConfigureAwait(false);

            // Do some Events logic...

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
