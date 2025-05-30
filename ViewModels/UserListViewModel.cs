using System.Text.Json.Serialization;

namespace TheApp.ViewModels;

public class UserListViewModel
{
    [JsonPropertyName("id")] public required string Id { get; set; }

    [JsonPropertyName("name")] public required string Name { get; set; }

    [JsonPropertyName("email")] public required string Email { get; set; }

    [JsonPropertyName("lastLoginTime")] public DateTime? LastLoginTime { get; set; }

    [JsonPropertyName("isBlocked")] public bool IsBlocked { get; set; }
}