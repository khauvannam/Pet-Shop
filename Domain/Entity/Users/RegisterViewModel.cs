using System.ComponentModel.DataAnnotations;

namespace Domain.Entity.Users;

public sealed class RegisterViewModel
{
    [EmailAddress]
    [Required]
    public string Email { get; init; } = null!;

    [Required]
    public string UserName { get; init; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; init; }

    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; init; }
}
