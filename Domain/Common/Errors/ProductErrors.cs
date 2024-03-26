namespace Domain.Common.Errors;

public static class ProductErrors
{
    public static Error NotFound = new("Favorite.NotFound", "Can not find this Favorite");
}