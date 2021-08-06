using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace DatingApp.Api.Extensions
{
    public static class SwaggerExtension
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "DatingApp", Version = "v1" });
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Auth Bearer Scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                options.AddSecurityDefinition("Bearer", securitySchema);
                var securityRequirement = new OpenApiSecurityRequirement { { securitySchema, new[] { "Bearer" } } };
                options.AddSecurityRequirement(securityRequirement);
            });
        }


     

        public static IApplicationBuilder USeClientApi(this IApplicationBuilder app)
        {
            app.UseSwagger();
            return app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DatingApp");



            });
        }
    }
}
