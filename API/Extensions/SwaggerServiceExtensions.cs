using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocs(this IServiceCollection services)
        {
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new OpenApiInfo { Title = "shopExp", Version = "v1" });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerMiddleware(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(s.RoutePrefix) ? "." : "..";
                s.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "expShop API");
            });

            return app;
        }
    }
}
