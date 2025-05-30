using System.ComponentModel.DataAnnotations;

namespace TheApp.ViewModels;

public class RegisterViewModel : AuthViewModel
{
    [Required] public required string Name { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public required string ConfirmPassword { get; set; }
}