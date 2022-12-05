using Microsoft.EntityFrameworkCore;
using PetPal_Model.Models;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace PetPal_DataAccess.Data
{
    public class Seed
    {
        public static async Task SeedUsers(ApplicationDbContext context)
        {
            if (await context.AppUsers.AnyAsync()) return;

            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();

                user.Username = user.Username.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                user.PasswordSalt = hmac.Key;

                context.AppUsers.Add(user);
            }
            await context.SaveChangesAsync();
        }
    }
}
