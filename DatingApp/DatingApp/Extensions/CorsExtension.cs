using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Api.Extensions
{
    public static class CorsExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        public static IApplicationBuilder UseCorswithPolicy(this IApplicationBuilder builder)
        {
            return builder.UseCors("CorsPolicy");
        }
        
    }
}
