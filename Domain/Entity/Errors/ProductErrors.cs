namespace Domain.Entity.Errors;

public static class ProductErrors
{
    public static Error NotFound = new("FavoriteProduct.NotFound","Can not find this FavoriteProduct");
}