using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace ACME.Store.Presentation.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSwaggerGenConfigurations(this IServiceCollection services)
        {
            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "ACME Store!",
                    Version = "v1",
                    Contact = new OpenApiContact()
                    {
                        Name = "Alonso de Oliveira",
                        Email = "alonsoboj@gmail.com",
                        Url = new Uri("https://linkedin.com/in/alonso-de-oliveira"),
                    },

                    License = new OpenApiLicense()
                    {
                        Name = "The Unlicense",
                        Url = new Uri("https://unlicense.org")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                cfg.IncludeXmlComments(xmlPath);

                cfg.DescribeAllParametersInCamelCase();
            });

            return services;
        }
    }
}
