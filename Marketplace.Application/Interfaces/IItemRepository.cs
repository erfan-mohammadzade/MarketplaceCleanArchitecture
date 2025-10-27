namespace Marketplace.Application.Interfaces;
using Marketplace.Domain.Entities;
public interface IItemRepository
{
    Task<Item?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IEnumerable<Item>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(Item item, CancellationToken ct = default);
    void Update(Item item);
    void Remove(Item item);
    Task SaveChangesAsync(CancellationToken ct = default);
}