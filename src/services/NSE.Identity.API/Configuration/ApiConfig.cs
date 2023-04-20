using NSE.Identity.API.Extensions;
using NSE.Identity.API.Interfaces;
using NSE.Identity.API.Services;

namespace NSE.Identity.API.Configuration
{
    public static class ApiConfig
    {

        public static void addApiConfig(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddMemoryCache();
            RegisterHandlers(services);
        }

        public static void RegisterHandlers(this IServiceCollection services)
        {
            services.AddScoped<AuthSettings>();
            services.AddScoped<IIdentityHandler, IdentityHandler>();
        }
    }
}
