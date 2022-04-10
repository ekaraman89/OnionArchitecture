using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OnionArchitecture.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<OnionArchitectureDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString));
        }
    }
}
