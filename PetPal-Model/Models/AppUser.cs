namespace PetPal_Model.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string? Username { get; set; } // Should not be nullable
        public string? KnownAs { get; set; } // Should not be nullable
        public string? Gender { get; set; } // Should not be nullable
        public string? Mood { get; set; } // Should not be nullable
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
        public List<Photo> Photos { get; set; } = new();

        public List<UserLike> LikedByUsers { get; set; } 
        public List<UserLike> LikedUsers { get; set; } 

        public List<Message> MessagesSent { get; set; }
        public List<Message> MessagesRecieved { get; set; }
    }
}
