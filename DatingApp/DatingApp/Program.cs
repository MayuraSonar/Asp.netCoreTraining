using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.DataModel.Context;
using DatingApp.DataModel.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DatingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host= CreateHostBuilder(args).Build();
            var scope = host.Services.CreateScope();
            var service = scope.ServiceProvider;
            try
            {
                var context = service.GetRequiredService<DatingAppDbContext>();
                Seed.SeedUsers(context);
                context.Database.Migrate();
               
            }

            catch(Exception ex)
            {
                var logger = service.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "Migration Failed!!");
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
