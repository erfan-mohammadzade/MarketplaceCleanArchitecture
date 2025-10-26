
using Marketplace.Domain.Entities;
public interface IUserRepository
{
   Task<User?> GetByIdWithItemAsync(int id, CancellationToken cancellationToken = default);
   Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default);
   Task AddAsync(User user, CancellationToken cancellationToken = default);
   void Update(User user);
   void Delete(User user);
   Task SaveAsync(CancellationToken cancellationToken = default);
}