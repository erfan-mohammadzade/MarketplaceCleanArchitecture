using Marketplace.Domain.Entities;
using Marketplace.Infrustructure.Presentation;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrustructure.Services;

public class UserRepository : IUserRepository
{
    private readonly DatabaseManager _databaseManager;

    public UserRepository(DatabaseManager databaseManager)
    {
        _databaseManager = databaseManager;
    }
    public async Task<User?> GetByIdWithItemAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _databaseManager.Users.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _databaseManager.Users.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await _databaseManager.AddAsync(user);
    }
    public void Delete(User user)
    {
        _databaseManager.Remove(user);
    }

    public void Update(User user)
    {
        _databaseManager.Update(user);
    }

    public Task SaveAsync(CancellationToken cancellationToken = default)
    {
        return _databaseManager.SaveChangesAsync(cancellationToken);
    }
}