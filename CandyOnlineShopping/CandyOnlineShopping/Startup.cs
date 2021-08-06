using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyOnlineShopping.Models.DataModels;
using CandyOnlineShopping.Models.Entity;
using CandyOnlineShopping.Models.Interfaces;
using CandyOnlineShopping.Models.Repositories;
using CandyOnlineShopping.Models.Services;
using CandyOnlineShopping.Models.Services.Interfaces;
using CandyOnlineShopping.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CandyOnlineShopping
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICandyRepsoitory, CandyRepository>();
            services.AddScoped<ICandyService, CandyService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IShoppingCartItemRepository, ShoppingCartItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
           
            services.AddSingleton<IEmailSender, EmailSender>();
            services.Configure<EmailOptions>(Configuration);
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            }).AddDefaultUI().AddEntityFrameworkStores<AppDbContext>().AddSignInManager().AddDefaultTokenProviders();
            services.AddHttpContextAccessor();
               services.AddSession();
            services.AddScoped<ShoppingCart>(sp =>ShoppingCart.GetCart(sp));
            services.AddRazorPages();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(name: "default",
                    pattern: "{controller=Candy}/{action=List}/{id?}"


                );

                endpoints.MapRazorPages();

            });
            }
    }
}
