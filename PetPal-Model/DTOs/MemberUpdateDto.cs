using PetPal_Model.Enums;

namespace PetPal_Model.DTOs
{
    public class MemberUpdateDto
    {
        public string? Introduction { get; set; }
        public string? LookingFor { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Gender { get; set; }
        public string? Mood { get; set; }
    }
}
