using Microsoft.AspNetCore.Mvc;
using SportFwd.Models;

namespace SportFwd.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            // You should fetch real athlete data here
            var users = new List<User>
            {
                new User { Id = "1", Name = "Roshan", Role = "Athlete", Photo = "cricket.jpg" },
                new User { Id = "2", Name = "Gain", Role = "Athlete", Photo = "football.jpg" }
            };

            return View(users);
        }
    }
}

