using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SportFwd.Models;
using SportFwd.Services;

public class AccountController : Controller
{
    private readonly FirebaseService _fb;

    public AccountController()
    {
        _fb = new FirebaseService();
    }

    public IActionResult Login() => View();
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(string name, string email, string role)
    {
        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Name = name,
            Email = email,
            Role = role
        };
        await _fb.SetAsync($"Users/{email}", user);
        return RedirectToAction("Login");
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string role)
    {
        var response = await _fb.GetAsync($"Users/{email}");
        var user = response.ResultAs<User>();
        if (user != null && user.Role == role)
        {
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserRole", user.Role);
            return RedirectToAction("Dashboard", "Home");
        }
        ViewBag.Error = "Invalid login.";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
