using Microsoft.AspNetCore.Mvc;

namespace TheApp.Controllers;

public class HomeController : BaseController
{
    public IActionResult Index(string? blocked = null)
    {
        HandleBlockedParameter(blocked);
        return View();
    }
}