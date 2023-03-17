using Microsoft.OpenApi.Models;

namespace NSE.Identity.API.Configuration
{
    public static class SwaggerConfiguration
    {

        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Nerd Store Enterprise Identity API",
                    Description = "The purpose of this API is to register new accounts and authenticate created accounts",
                    Contact = new OpenApiContact() { Name = "Gabriel Queiroz", Email = "gabriel@developer,com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                }));
          

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app, string baseUrl, string serviceName)
        {

            app.UseSwagger(c => {
                c.RouteTemplate = baseUrl + "/swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/{baseUrl}/swagger/v1/swagger.json", serviceName);
                c.RoutePrefix = $"{baseUrl}/swagger";
            });

            return app;
        }

    }
}
