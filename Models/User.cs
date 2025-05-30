using Microsoft.AspNetCore.Identity;

namespace TheApp.Models;

public class User : IdentityUser
{
    public string? Name { get; set; }
    public DateTime? LastLoginTime { get; set; }
    public bool IsBlocked { get; set; }
    public DateTime RegistrationTime { get; set; }
}