namespace Domain.Entities.Promotions;

public class Promotion
{
    public string PromotionId { get; } = Guid.NewGuid().ToString();
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int DiscountRate { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; }
}
