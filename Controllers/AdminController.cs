using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SportFwd.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FireSharp.Response;
using SportFwd.Services;

public class AdminController : Controller
{
    FirebaseService _fb = new FirebaseService();

    // List all users in the Firebase Users node
    public async Task<IActionResult> ListAllUsers()
    {
        var response = await _fb.GetAsync("Users");
        var users = response.ResultAs<Dictionary<string, User>>();
        return View(users.Values.ToList());
    }

    // Optional: Display system logs or mock logs
    public IActionResult SystemLogs() => View();
}
