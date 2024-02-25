namespace WebShop.Domain.Entities;

public class Image
{
    public int Id { get; set; }
    public string Title { get; set; }
    public byte[] Data { get; set; }
    
    private Image() { }
    
    public Image(string title, byte[] data)
    {
        Title = title;
        Data = data;
    }
}