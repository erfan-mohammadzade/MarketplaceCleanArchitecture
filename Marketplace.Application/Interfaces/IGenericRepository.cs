namespace Marketplace.Application.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id, CancellationToken cancellationToken =  default);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task SaveAsync(CancellationToken cancellationToken = default);
}