namespace Domain.Entity.Users;

public record RegisterViewModel(
    string? Email,
    string? UserName,
    string? Password,
    string? ConfirmPassword
);
