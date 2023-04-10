namespace PetPal_Model.DTOs
{
    public class UserDto
    {
        public string? Username { get; set; }
        public string? KnownAs { get; set; }
        public string? Token { get; set; }
        public string? PhotoUrl { get; set; }
        public string? Mood { get; set; } //FIX so these 5 dont have "?". Member-Edit component (frontend) wont work without the nullable syntax.
    }
}
