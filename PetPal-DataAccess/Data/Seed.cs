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

            var userData = await File.ReadAllTextAsync("../PetPal-DataAccess/Data/UserSeedData.json");

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

        public static async Task SeedMessages(ApplicationDbContext context)
        {
            if (await context.Messages.AnyAsync()) return;

            var userData = await File.ReadAllTextAsync("../PetPal-DataAccess/Data/MessageSeedData.json");

            var messages = JsonSerializer.Deserialize<List<Message>>(userData);

            foreach (var message in messages)
            {
                message.SenderUsername = message.SenderUsername.ToLower();
                message.RecipientUsername = message.RecipientUsername.ToLower();
                message.MessageSent = DateTime.UtcNow;

                context.Messages.Add(message);
            }
            await context.SaveChangesAsync();
        }

        public static async Task SeedLikes(ApplicationDbContext context)
        {
            if (await context.Likes.AnyAsync()) return;

            var userData = await File.ReadAllTextAsync("../PetPal-DataAccess/Data/LikeSeedData.json");

            var likes = JsonSerializer.Deserialize<List<UserLike>>(userData);

            foreach(var like in likes)
            {
                context.Likes.Add(like);
            }
            await context.SaveChangesAsync();
        }
    }
}
