using Marketplace.Application.Interfaces;
using Marketplace.Domain.Entities;
using Marketplace.Infrustructure.Presentation;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrustructure.Services;

public class ItemRepository : IItemRepository
{
    private readonly DatabaseManager _databaseManager;

    public ItemRepository(DatabaseManager databaseManager)
    {
        _databaseManager = databaseManager;
    }

    public async Task<Item?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await _databaseManager.Items.FindAsync(new object[] { id }, ct);
    }

    public async Task<IEnumerable<Item>> GetAllAsync(CancellationToken ct = default)
    {
        return await _databaseManager.Items.ToListAsync(cancellationToken: ct);
    }

    public async Task AddAsync(Item item, CancellationToken ct = default)
    {
        await _databaseManager.Items.AddAsync(item, ct);
    }

    public void Update(Item item)
    {
        _databaseManager.Items.Update(item);
    }

    public void Remove(Item item)
    {
        _databaseManager.Remove(item);
    }

    public async Task SaveChangesAsync(CancellationToken ct = default)
    {
        await _databaseManager.SaveChangesAsync(ct);
    }
}