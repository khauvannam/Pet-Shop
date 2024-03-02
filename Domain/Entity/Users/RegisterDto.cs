namespace Domain.Entity.Users;

public class RegisterDto
{
    public string Email { get; init; }
    public string UserName { get; init; }
    public string Password { get; init; }
    public string ComfirmPassword { get; init; }
}
