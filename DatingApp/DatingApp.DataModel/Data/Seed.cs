using DatingApp.DataModel.Context;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using DatingApp.DataModel.Entities;

namespace DatingApp.DataModel.Data
{
   public static class Seed
    {
        public static void SeedUsers(DatingAppDbContext datingAppDbContext)
        {
            if(!datingAppDbContext.User.Any())
            {
                var userData = File.ReadAllText("C:\\EMIAspNetCoreTraining\\EMIAspNetCore\\DatingApp\\DatingApp.DataModel\\Data\\UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach( var user in users)
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash("password", out passwordHash, out passwordSalt);
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    user.Name = user.Name.ToLower();
                    datingAppDbContext.User.Add(user);
                }

                datingAppDbContext.SaveChanges();
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
