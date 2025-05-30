namespace TheApp.Services;

public interface IUserActionStrategy
{
    Task<(bool Succeeded, string Error)> ExecuteAsync(List<string> userIds);
    string SuccessMessage { get; }
}