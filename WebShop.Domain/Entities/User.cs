namespace WebShop.Domain.Entities;

public class User(string email)
{
    public int Id { get; private set; }
    public string Email { get; set; } = email;
}