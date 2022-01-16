using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OA.Core.Interfaces;
using OA.Core.Services;

namespace OA.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection serviceCollection, IConfiguration config)
        {
            serviceCollection.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
