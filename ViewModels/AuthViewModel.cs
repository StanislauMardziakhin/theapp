using System.ComponentModel.DataAnnotations;

namespace TheApp.ViewModels;

public class AuthViewModel
{
    [Required] [EmailAddress] public required string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}