using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SportFwd.Models;
using SportFwd.Services; // Assuming FirebaseService is in Services folder
using System;
using System.Threading.Tasks;

namespace SportFwd.Controllers
{
    public class AthleteController : Controller
    {
        private readonly FirebaseService _fb = new FirebaseService();

        public IActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadMedia(IFormFile file, string title)
        {
            if (file != null && file.Length > 0)
            {
                var media = new Media
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = title,
                    Url = "https://example.com/media/url", // Replace this with your actual media upload URL or logic
                    AthleteId = HttpContext.Session.GetString("UserEmail"),
                    UploadedOn = DateTime.UtcNow.ToString("s")
                };

                await _fb.SetAsync($"Media/{media.Id}", media);
            }

            return RedirectToAction("Profile");
        }
    }
}
