using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheApp.Constants;
using TheApp.Services;
using TheApp.ViewModels;

namespace TheApp.Controllers;

[Authorize]
public class UsersController : Controller
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var users = await _userService.GetAllUsersAsync();
        ViewBag.CurrentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return View(users);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Json(users);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Action(ActionViewModel model)
    {
        if (model.UserIds == null || !model.UserIds.Any())
            return Json(new { success = false, message = Messages.Users.SelectAtLeastOneUser });

        var (succeeded, error, message, isCurrentUserAffected) =
            await _userService.ProcessUserActionAsync(model.Action, model.UserIds, true);

        if (succeeded && isCurrentUserAffected &&
            (model.Action == UserAction.Block || model.Action == UserAction.Delete))
            return Json(new { success = true, redirectTo = Url.Action("Login", "Auth") });

        return Json(new { success = succeeded, message = succeeded ? message : error });
    }
}