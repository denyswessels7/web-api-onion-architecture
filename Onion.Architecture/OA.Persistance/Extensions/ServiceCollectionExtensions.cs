using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OA.Core.Repository;
using OA.Persistance.Context;
using OA.Persistance.Repository;

namespace OA.Persistance.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection serviceCollection, IConfiguration config)
        {
            serviceCollection.AddDbContext<OADbContext>(options =>
            options.UseSqlServer(
                config.GetConnectionString("CS"),
                b=> b.MigrationsAssembly(typeof(OADbContext).Assembly.FullName)));

            serviceCollection.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
