namespace PetPal_Business.Helpers
{
    public class UserParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public string? CurrentUsername { get; set; }
        public string? Mood { get; set; }
        public int MinAge { get; set; } = 1;
        public int MaxAge { get; set; } = 100; //change this so it makes sense in "dog years". 1-14 ish.
        public string OrderBy { get; set; } = "lastActive";

    }
}
