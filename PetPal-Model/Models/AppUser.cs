using PetPal_Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetPal_Model.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        public string? Introduction { get; set; }
        public string? LookingFor { get; set; }
        public string? City { get; set; }
        public Country? Country { get; set; }
        public Language? Language { get; set; }
        public List<Animal> Animals { get; set; } = new();

        //public int GetAge()
        //{
        //    return DateOfBirth.CalculateAge();
        //}

    }
}
