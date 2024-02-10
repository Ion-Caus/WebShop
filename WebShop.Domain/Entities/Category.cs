namespace WebShop.Domain.Entities;

public class Category
{
    public Category(string name)
    {
        Name = name;
    }
    
    private Category() { }

    public int Id { get; private set; }
    public string Name { get; set; }
}