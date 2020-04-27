using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RatesCalc.Infrastructure.Data;

namespace RatesCalc.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services) =>
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "RatesCalc"));
    }
}
