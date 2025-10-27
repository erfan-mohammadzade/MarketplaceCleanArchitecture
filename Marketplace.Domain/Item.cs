namespace Marketplace.Domain.Entities;
public class Item
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price {get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();    
}