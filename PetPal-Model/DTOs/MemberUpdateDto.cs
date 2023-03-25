using PetPal_Model.Enums;

namespace PetPal_Model.DTOs
{
    public class MemberUpdateDto
    {
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string City { get; set; }
        public Country? Country { get; set; }
    }
}
