using DatingApp.Api.Services.Interfaces;
using DatingApp.DataModel.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DatingApp.Api.Services
{
    public class TokenService : ITokenService
    {
        public readonly SymmetricSecurityKey _symmetricSecurityKey;
        public TokenService(IConfiguration configuration)
        {
            _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }
            public string CreateToken(User user)
        {
            var claim = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
               new Claim(JwtRegisteredClaimNames.UniqueName,user.Name)
            };
            var credential = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.Now.AddDays(10),
                SigningCredentials = credential,
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
