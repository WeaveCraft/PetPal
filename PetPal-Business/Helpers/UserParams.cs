namespace PetPal_Business.Helpers
{
    public class UserParams : PaginationParams
    {
        public string? CurrentUsername { get; set; }
        public string? Mood { get; set; }
        public int MinAge { get; set; } = 1;
        public int MaxAge { get; set; } = 100; //change this so it makes sense in "dog years". 1-14 ish.
        public string OrderBy { get; set; } = "lastActive";

    }
}
