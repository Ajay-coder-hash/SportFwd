// FanController.cs
using Microsoft.AspNetCore.Mvc;
using SportFwd.Models; // Ensure this matches your namespace for the User model
using FireSharp.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportFwd.Services;

public class FanController : Controller
{
    FirebaseService _fb = new FirebaseService();

    public async Task<IActionResult> ExploreAthletes()
    {
        // Retrieve athletes from Firebase
        FirebaseResponse response = await _fb.GetAsync("Users");
        var users = response.ResultAs<Dictionary<string, User>>();
        var athletes = users.Values.Where(u => u.Role == "Athlete").ToList();
        return View(athletes);
    }

    public async Task<IActionResult> Follow(string id)
    {
        // Logic to follow athlete (e.g., store follow info in Firebase)
        string fanEmail = HttpContext.Session.GetString("UserEmail");
        string safeEmail = fanEmail.Replace("@", "_at_").Replace(".", "_dot_");

        // Optional: Save in /Follows/{FanEmail}/{AthleteId}
        await _fb.SetAsync($"Follows/{safeEmail}/{id}", true);
        return RedirectToAction("ExploreAthletes");
    }
}
