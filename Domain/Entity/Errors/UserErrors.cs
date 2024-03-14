namespace Domain.Entity.Errors;

public static class UserErrors
{
    public static readonly Error NotFound = new("User.NotFound", "User not exist, try again");
    public static readonly Error Invalid =
        new("User.Invalid", "Wrong email or password, try again");

    public static Error IsUsed(string email, string username) =>
        new("User.IsUsed", $"Your email {email} or username {username} is used, try another");
}
