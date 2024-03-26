using static System.String;

namespace Domain.Common.Errors;

public sealed record Error(string Code, string Description)
{
    public static readonly Error None = new(Empty, Empty);
    public static readonly Error NotExpect =
        new("Error.NotExpect", "Something wrong happen, try again later");
}
