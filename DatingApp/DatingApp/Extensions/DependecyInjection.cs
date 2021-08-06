using AutoMapper;
using DatingApp.Api.Helper;
using DatingApp.Api.Mapper;
using DatingApp.Api.Services;
using DatingApp.Api.Services.Interfaces;
using DatingApp.DataModel.Repositories;
using DatingApp.DataModel.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DatingApp.Api.Extensions
{
    public static class DependecyInjection
    {
        public static void ConfigureDomainServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IPhotoRepository, PhotoResposiotry>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters =
                new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"])),
                    ValidateIssuer=false,
                    ValidateAudience=false

                });
        }
    }
}
