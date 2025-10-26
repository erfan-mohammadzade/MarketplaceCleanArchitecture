

using Marketplace.Domain.Entities;

public interface IUserService
{
    Task<User?> GetUserWithItemsAsync(int id, CancellationToken cancellationToken = default);
    Task<int> CreateUserAsync(User user, CancellationToken cancellationToken = default);
    Task AddItemToUserAsync(int userId, Item item, CancellationToken cancellationToken = default);
}