namespace WebShop.Domain.Entities;

public class Cart
{
    public Guid CardId { get; private set; } = Guid.NewGuid();

    public int Id { get; private set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public List<CartItem> CartItems { get; set; } = new();
    
    // Add UserID if you have user authentication
    // public int UserID { get; set; }
    // public User User { get; set; }

    public Cart() { }
}