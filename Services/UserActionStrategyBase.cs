using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheApp.Constants;
using TheApp.Models;

namespace TheApp.Services;

public abstract class UserActionStrategyBase : IUserActionStrategy
{
    protected readonly UserManager<User> UserManager;

    protected UserActionStrategyBase(UserManager<User> userManager)
    {
        UserManager = userManager;
    }

    public abstract string SuccessMessage { get; }

    public abstract Task<(bool Succeeded, string Error)> ExecuteAsync(List<string> userIds);

    protected async Task<(bool Succeeded, string Error)> UpdateUsersAsync(List<string> userIds,
        Func<User, Task> updateAction, string errorMessageTemplate)
    {
        try
        {
            var users = await GetValidUsersAsync(userIds);
            var errors = new List<string>();

            foreach (var user in users)
                try
                {
                    await updateAction(user);
                    var result = await UserManager.UpdateAsync(user);
                    if (!result.Succeeded) errors.Add(string.Format(errorMessageTemplate, user.Email));
                }
                catch
                {
                    errors.Add(string.Format(errorMessageTemplate, user.Email));
                }

            return errors.Any() ? (false, string.Join("; ", errors)) : (true, string.Empty);
        }
        catch (UserActionException ex)
        {
            return (false, ex.Message);
        }
        catch
        {
            return (false, Messages.Common.Error);
        }
    }

    protected async Task<List<User>> GetValidUsersAsync(List<string> userIds)
    {
        var users = await UserManager.Users
            .Where(u => userIds.Contains(u.Id))
            .ToListAsync();

        var foundUserIds = users.Select(u => u.Id).ToHashSet();
        var missingUserIds = userIds.Except(foundUserIds).ToList();

        if (missingUserIds.Any())
            throw new UserActionException($"Пользователи с ID {string.Join(", ", missingUserIds)} не найдены.");

        return users;
    }
}

public class BlockUserStrategy : UserActionStrategyBase
{
    public BlockUserStrategy(UserManager<User> userManager) : base(userManager)
    {
    }

    public override string SuccessMessage => Messages.Users.UsersBlocked;

    public override async Task<(bool Succeeded, string Error)> ExecuteAsync(List<string> userIds)
    {
        return await UpdateUsersAsync(userIds, user =>
        {
            user.IsBlocked = true;
            return Task.CompletedTask;
        }, Messages.Users.BlockUserError);
    }
}

public class UnblockUserStrategy : UserActionStrategyBase
{
    public UnblockUserStrategy(UserManager<User> userManager) : base(userManager)
    {
    }

    public override string SuccessMessage => Messages.Users.UsersUnblocked;

    public override async Task<(bool Succeeded, string Error)> ExecuteAsync(List<string> userIds)
    {
        return await UpdateUsersAsync(userIds, user =>
        {
            user.IsBlocked = false;
            return Task.CompletedTask;
        }, Messages.Users.UnblockUserError);
    }
}

public class DeleteUserStrategy : UserActionStrategyBase
{
    public DeleteUserStrategy(UserManager<User> userManager) : base(userManager)
    {
    }

    public override string SuccessMessage => Messages.Users.UsersDeleted;

    public override async Task<(bool Succeeded, string Error)> ExecuteAsync(List<string> userIds)
    {
        try
        {
            var users = await GetValidUsersAsync(userIds);
            var errors = new List<string>();

            foreach (var user in users)
                try
                {
                    var result = await UserManager.DeleteAsync(user);
                    if (!result.Succeeded) errors.Add(string.Format(Messages.Users.DeleteUserError, user.Email));
                }
                catch
                {
                    errors.Add(string.Format(Messages.Users.DeleteUserError, user.Email));
                }

            return errors.Any() ? (false, string.Join("; ", errors)) : (true, string.Empty);
        }
        catch (UserActionException ex)
        {
            return (false, ex.Message);
        }
        catch
        {
            return (false, Messages.Common.Error);
        }
    }
}

public class UserActionException : Exception
{
    public UserActionException(string message) : base(message)
    {
    }
}