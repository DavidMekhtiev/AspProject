using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace FirstProject
{
    public static class ConfigureContainerExtensions
    {
        public static void AddApiVersions(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddApiVersioning(
                config =>
                {
                    config.ReportApiVersions = true;
                    config.AssumeDefaultVersionWhenUnspecified = true;
                    config.DefaultApiVersion = new ApiVersion(1, 0);
                    config.ApiVersionReader = new HeaderApiVersionReader("api-version");
                });
        }
        public static void AddSwagger(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sapsan", Version = "v1" });
            });
        }

    }
}
