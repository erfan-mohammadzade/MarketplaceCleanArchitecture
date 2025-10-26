
namespace Marketplace.Domain.Entities;
public class User
{
    public int UserId { get; set; }
    public string Username { set; get; }
    
    public string Password { get; set; }
    
    public string Email { get; set; }
    
   public ICollection<Item>? Items { get; set; } = new List<Item>();
}