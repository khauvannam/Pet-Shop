namespace Domain.Entity.Errors;

public static class UserErrors
{
    public static readonly Error NotFound = new("User.NotFound", "User not exist, try agan");
    public static readonly Error Invalid =
        new("User.Invalid", "Wrong email or password, try again");
}
