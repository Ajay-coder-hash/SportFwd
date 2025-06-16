using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.Extensions.Configuration;

namespace SportFwd.Services
{
    public class FirebaseService
    {
        private IFirebaseClient client;

        public FirebaseService()
        {
            var config = new FirebaseConfig
            {
                AuthSecret = "your-firebase-secret",
                BasePath = "https://sportfwd-70e02-default-rtdb.firebaseio.com/"
            };
            client = new FireSharp.FirebaseClient(config);
        }

        public async Task SetAsync<T>(string path, T data) => await client.SetAsync(SanitizePath(path), data);
        public async Task<FirebaseResponse> GetAsync(string path) => await client.GetAsync(SanitizePath(path));

        private string SanitizePath(string path)
        {
            return path.Replace("@", "_at_").Replace(".", "_dot_").Replace("#", "_hash_")
                       .Replace("$", "_dollar_").Replace("[", "_ob_").Replace("]", "_cb_");
        }
    }
}
