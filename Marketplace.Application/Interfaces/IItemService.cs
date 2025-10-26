
using Marketplace.Domain.Entities;

public interface IItemService
{
    Task<Item?>GetByIdAsync(Guid id);
    Task<Item?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddItemAsync(Item item, CancellationToken cancellationToken = default);

    public void RemoveItem(Item item);
    public void Update(Item item);
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);
}