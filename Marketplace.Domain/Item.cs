namespace Marketplace.Domain.Entities;
public class Item
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public decimal Price {get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();    
}