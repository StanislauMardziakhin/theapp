using TheApp.ViewModels;

namespace TheApp.Services;

public interface IUserService
{
    Task<(bool Succeeded, string[] Errors)> RegisterAsync(RegisterViewModel model);
    Task<(bool Succeeded, string Error)> LoginAsync(LoginViewModel model);
    Task LogoutAsync();
    Task<List<UserListViewModel>> GetAllUsersAsync();

    Task<(bool Succeeded, string Error, string Message, bool IsCurrentUserBlocked)> ProcessUserActionAsync(
        UserAction action, List<string> userIds, bool refreshCurrentUserSession);
}