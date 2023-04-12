using PetPal_Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetPal_Model.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? KnownAs { get; set; }
        public string Gender { get; set; }
        public string Mood { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        public string? Introduction { get; set; }
        public string? LookingFor { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Language { get; set; }
        public List<Animal> Animals { get; set; } = new();
        public List<Photo> Photos { get; set; } = new();

        public List<UserLike> LikedByUsers { get; set; } 
        public List<UserLike> LikedUsers { get; set; } 

        public List<Message> MessagesSent { get; set; }
        public List<Message> MessagesRecieved { get; set; }
    }
}
