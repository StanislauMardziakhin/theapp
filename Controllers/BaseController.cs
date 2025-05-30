using Microsoft.AspNetCore.Mvc;
using TheApp.Constants;

namespace TheApp.Controllers;

public class BaseController : Controller
{
    protected void HandleBlockedParameter(string? blocked)
    {
        if (blocked == "true") ViewBag.ErrorMessage = Messages.Auth.AccountBlocked;
    }
}