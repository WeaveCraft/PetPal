using PetPal_Model.Enums;

namespace PetPal_Model.DTOs
{
    public class AnimalDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? KnownAs { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Interests { get; set; }
        public string? FavoriteTreat { get; set; }
        public string? FavoriteToy { get; set; }
        //    public string PhotoUrl { get; set; }
        //    public List<PhotoDto> Photos { get; set; }
    }
}
