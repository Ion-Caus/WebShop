using WebShop.Domain.ValueObjects;

namespace WebShop.Domain.Entities;

public class OrderItem(int quantity, Price unitPrice, Order order, Product product)
{
    public Guid OrderItemId { get; private set; } = Guid.NewGuid();
    
    public int Id { get; private set; }
    public int Quantity { get; set; } = quantity;
    public Price UnitPrice { get; set; } = unitPrice;

    public int OrderId { get; set; }
    // public Order Order { get; set; } = order;

    public int ProductId { get; set; }
    public Product Product { get; set; } = product;
}