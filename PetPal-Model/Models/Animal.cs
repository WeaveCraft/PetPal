using PetPal_Model.Enums;

namespace PetPal_Model.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string? Name { get; set; }   
        public AnimalType Race { get; set; }
        public int Age { get; set; }
        public string? ColorType { get; set; }
    }
}
