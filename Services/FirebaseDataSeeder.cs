using SportFwd.Models;

namespace SportFwd.Services
{
    public class FirebaseDataSeeder
    {
        private readonly FirebaseService _firebase;

        public FirebaseDataSeeder()
        {
            _firebase = new FirebaseService();
        }

        public async Task SeedAllAsync()
        {
            // 1. Seed User
            var user = new User
            {
                Id = "u1",
                Name = "Ajay",
                Email = "user1@gmail.com",
                Role = "Athlete"
            };

            string safeEmail = user.Email.Replace("@", "_at_").Replace(".", "_dot_");

            await _firebase.SetAsync($"Users/{safeEmail}", user);

            // 2. Seed Team
            var team = new Team
            {
                Id = "team1",
                Name = "RCB",
                Members = new List<string> { "u1", "u2" }
            };
            await _firebase.SetAsync($"Teams/{team.Id}", team);

            // 3. Seed Media
            var media = new Media
            {
                Id = "media123",
                AthleteId = "u1",
                Title = "Game Highlights - May 2025",
                Url = "https://example.com/video.mp4",
                UploadedOn = DateTime.UtcNow.ToString("yyyy-MM-dd")
            };
            await _firebase.SetAsync($"Media/{media.Id}", media);
        }
    }
}
