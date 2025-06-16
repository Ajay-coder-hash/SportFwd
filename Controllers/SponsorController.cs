using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SportFwd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportFwd.Services;

public class SponsorController : Controller
{
    FirebaseService _fb = new FirebaseService();

    public async Task<IActionResult> DiscoverAthletes()
    {
        // Retrieve users from Firebase and filter for role == "Athlete"
        var response = await _fb.GetAsync("Users");
        var users = response.ResultAs<Dictionary<string, User>>();
        var athletes = users.Values.Where(u => u.Role == "Athlete").ToList();
        return View(athletes);
    }

    public async Task<IActionResult> SupportAthlete(string id)
    {
        // Save sponsorship info under /Support/{SponsorEmail}/{AthleteId}
        string sponsorEmail = HttpContext.Session.GetString("UserEmail");
        string safeEmail = sponsorEmail.Replace("@", "_at_").Replace(".", "_dot_");
        await _fb.SetAsync($"Support/{safeEmail}/{id}", true);
        return RedirectToAction("DiscoverAthletes");
    }
}
