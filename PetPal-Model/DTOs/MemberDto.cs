using PetPal_Model.Enums;

namespace PetPal_Model.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public int Age { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string? Introduction { get; set; }
        public string? LookingFor { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Language { get; set; }
        public List<AnimalDto> Animals { get; set; }
        public string PhotoUrl { get; set; }
        public List<PhotoDto> Photos { get; set; }
    }
}

