using Marketplace.Domain.Entities;
using Marketplace.Infrustructure.Presentation;
using Microsoft.EntityFrameworkCore;
namespace Marketplace.Infrustructure.Model.Services;

public class ItemRepository : IItemService
{
    private readonly DatabaseManager _databaseManager;

    public ItemRepository(DatabaseManager databaseManager)
    {
        _databaseManager = databaseManager;
    }

    public Task<Item?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Item?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _databaseManager.Items.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task AddItemAsync(Item item, CancellationToken cancellationToken = default)
    {
        await _databaseManager.Items.AddAsync(item, cancellationToken);
    }

    public void RemoveItem(Item item)
    {
        _databaseManager.Remove(item);
    }

    public void Update(Item item)
    {
        _databaseManager.Update(item);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        _databaseManager.SaveChangesAsync(cancellationToken);
    }
}