namespace Domain.Entity.Errors;

public static class UserErrors
{
    public static readonly Error NotFound = new("User.NotFound", "User not exist, try again");
    public static readonly Error Invalid =
        new("User.Invalid", "Wrong email or password, try again");

    public static readonly Error SameInfo =
        new("User.SameInfo", "Your email or username is used, try another");
}
