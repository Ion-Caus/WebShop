using WebShop.Domain.ValueObjects;

namespace WebShop.Domain.Entities;

public class Order
{
    public Guid OrderId { get; private set; } = Guid.NewGuid();
    
    public int Id { get; private set; }
    
    // public int UserID { get; set; }
    // public User User { get; set; }

    public required DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;
    
    public required Price TotalAmount { get; set; }
    public required OrderStatus Status { get; set; } = OrderStatus.Pending;

    public List<OrderItem> OrderItems { get; set; } = new();
}