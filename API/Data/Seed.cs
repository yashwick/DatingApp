using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public static class Seed
    {
        public static async Task SeedUsers(DataContext context){
            if (await context.Users.AnyAsync())return;
            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            foreach(var user in users){
                using var hmac =new HMACSHA512();
                
                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password") );
                user.PasswordSalt = hmac.Key;

                context.Users.Add(user);

                await context.SaveChangesAsync();
            }//call this method in program.cs
        }
        //Static is used so that we won't create a new instance when this is used
    }
}