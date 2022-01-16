using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace OA.Api.Extensions
{
    public static class SwaggerConfig 
    {
        private const string _title = ".NET Core Web API";
        private const string _description = "Contains a list of the API calls required for this project";
        private const string _name = "Denys Wessels";
        private const string _email = "denyswessels7@gmail.com";
        private const string _so = "https://stackoverflow.com/users/923095/denys-wessels";
        private const string _mit = "https://opensource.org/licenses/MIT";

        public static void InitSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = _title,
                    Description = _description,
                    Contact = new OpenApiContact
                    {
                        Name = _name,
                        Email = _email,
                        Url = new Uri(_so)
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri(_mit)
                    },
                    Version = "v1"
                });

                //Configured in Properties -> Build -> XML documentation file
                var documentationFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var documentationFilePath = Path.Combine(AppContext.BaseDirectory, documentationFile);
                c.IncludeXmlComments(documentationFilePath);
            });
        }

        public static void InitSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "OA.Api");
            });
        }
    }
}