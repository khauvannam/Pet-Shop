namespace Domain.Entity.Products;

public record ProductDto(
    string? Name,
    string? Description,
    float? Price,
    string? Size,
    int QuantityInStock
);
