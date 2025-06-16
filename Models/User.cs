namespace SportFwd.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // Athlete, Fan, Sponsor
        public string Photo { get; set; } // <-- This is used for @athlete.Photo
    }
}
