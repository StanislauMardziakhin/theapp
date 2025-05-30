using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using TheApp.Constants;
using TheApp.Models;
using TheApp.ViewModels;

namespace TheApp.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly Dictionary<UserAction, IUserActionStrategy> _actionStrategies;

    public UserService(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _httpContextAccessor = httpContextAccessor;
        _actionStrategies = new Dictionary<UserAction, IUserActionStrategy>
        {
            { UserAction.Block, new BlockUserStrategy(userManager) },
            { UserAction.Unblock, new UnblockUserStrategy(userManager) },
            { UserAction.Delete, new DeleteUserStrategy(userManager) }
        };
    }

    public async Task<(bool Succeeded, string[] Errors)> RegisterAsync(RegisterViewModel model)
    {
        var user = new User
        {
            UserName = model.Email!,
            Email = model.Email!,
            Name = model.Name!,
            RegistrationTime = DateTime.UtcNow,
            LastLoginTime = DateTime.UtcNow
        };

        try
        {
            var result = await _userManager.CreateAsync(user, model.Password!);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return (true, []);
            }

            return (false, result.Errors.Select(e => e.Description).ToArray());
        }
        catch (PostgresException ex) when (ex.SqlState == "23505" && ex.ConstraintName != null &&
                                           ex.ConstraintName.Contains("Email"))
        {
            return (false, new[] { Messages.Auth.EmailAlreadyRegistered });
        }
        catch
        {
            return (false, new[] { Messages.Auth.RegistrationError });
        }
    }

    public async Task<(bool Succeeded, string Error)> LoginAsync(LoginViewModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email!);
        if (user == null) return (false, Messages.Auth.EmailNotRegistered);

        if (user.IsBlocked) return (false, Messages.Auth.AccountBlocked);

        var result = await _signInManager.PasswordSignInAsync(model.Email!, model.Password!, model.RememberMe, false);
        if (result.Succeeded)
        {
            user.LastLoginTime = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);
            return (true, string.Empty);
        }

        return (false, Messages.Auth.InvalidCredentials);
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<List<UserListViewModel>> GetAllUsersAsync()
    {
        return await _userManager.Users
            .OrderByDescending(u => u.LastLoginTime ?? DateTime.MinValue)
            .Select(u => new UserListViewModel
            {
                Id = u.Id,
                Name = u.Name ?? u.Email,
                Email = u.Email!,
                LastLoginTime = u.LastLoginTime,
                IsBlocked = u.IsBlocked
            })
            .ToListAsync();
    }

    public async Task<(bool Succeeded, string Error, string Message, bool IsCurrentUserBlocked)> ProcessUserActionAsync(
        UserAction action, List<string> userIds, bool refreshCurrentUserSession)
    {
        try
        {
            if (!_actionStrategies.TryGetValue(action, out var strategy))
                return (false, Messages.Users.InvalidAction, string.Empty, false);

            var (succeeded, error) = await strategy.ExecuteAsync(userIds);
            if (!succeeded) return (false, error, string.Empty, false);

            var isCurrentUserAffected = false;
            if (refreshCurrentUserSession && _httpContextAccessor.HttpContext != null)
            {
                var currentUserId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
                if (currentUserId != null && userIds.Contains(currentUserId))
                {
                    if (action == UserAction.Block || action == UserAction.Delete)
                    {
                        isCurrentUserAffected = true;
                        await _signInManager.SignOutAsync();
                    }
                    else if (action == UserAction.Unblock)
                    {
                        var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                        if (currentUser != null) await _signInManager.RefreshSignInAsync(currentUser);
                    }
                }
            }

            return (true, string.Empty, strategy.SuccessMessage, isCurrentUserAffected);
        }
        catch
        {
            return (false, Messages.Common.Error, string.Empty, false);
        }
    }
}