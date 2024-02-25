namespace WebShop.Domain.Entities;

public class Warehouse(string name, string address1, string address2, string city, string country)
{
    public int Id { get; private set; }
    public string Name { get; set; } = name;
    public string? Address1 { get; set; } = address1;
    public string? Address2 { get; set; } = address2;
    public string? City { get; set; } = city;
    public string? Country { get; set; } = country;
}