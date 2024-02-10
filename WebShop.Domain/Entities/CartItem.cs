namespace WebShop.Domain.Entities;

public class CartItem(int quantity, Cart cart, Product product)
{
    public Guid CartItemId { get; private set; } = Guid.NewGuid();
    
    public int Id { get; private set; }
    public int Quantity { get; set; } = quantity;

    public int ProductId { get; set; }
    public Product Product { get; set; } = product;
    
    
}