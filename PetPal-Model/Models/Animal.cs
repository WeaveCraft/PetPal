using PetPal_Logic.Extensions;
using PetPal_Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetPal_Model.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        public string? KnownAs { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public int Age { get; set; }
        public Gender? Gender { get; set; }
        public string? Interests { get; set; }
        public string? FavoriteTreat { get; set; }
        public string? FavoriteToy { get; set; }
        public List<Photo> Photos { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        //public int GetAge()
        //{
        //    return DateOfBirth.CalculateAge();
        //}
    }
}
