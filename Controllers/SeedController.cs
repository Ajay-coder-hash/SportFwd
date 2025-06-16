using Microsoft.AspNetCore.Mvc;
using SportFwd.Services;

namespace SportFwd.Controllers
{
    public class SeedController : Controller
    {
        public async Task<IActionResult> Run()
        {
            var seeder = new FirebaseDataSeeder();
            await seeder.SeedAllAsync();
            return Content("Data seeded successfully to Firebase.");
        }
    }
}
