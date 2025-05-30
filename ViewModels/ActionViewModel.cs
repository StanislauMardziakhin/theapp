namespace TheApp.ViewModels;

public enum UserAction
{
    Block,
    Unblock,
    Delete
}

public class ActionViewModel
{
    public List<string> UserIds { get; init; } = new();
    public UserAction Action { get; init; }
}