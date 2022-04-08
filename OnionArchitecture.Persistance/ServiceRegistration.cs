using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Application.Abstractions;
using OnionArchitecture.Persistance.Concrete;

namespace OnionArchitecture.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();
        }
    }
}
