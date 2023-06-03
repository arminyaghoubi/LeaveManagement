using HR.LeaveManagement.Domain.Common;
using System.Linq.Expressions;

namespace HR.LeaveManagement.Application.Contracts.Persistance;

public interface IGenericRepository<TEntity>
    where TEntity : BaseEntity
{
    Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
        Expression<Func<TEntity, object>> include = null,
        Expression<Func<TEntity, object>> order = null,
        bool ascending = true,
        bool disableTracking = true,
        int page = 1,
        int pageSize = 20,
        CancellationToken cancellation = default);
    Task<TEntity?> GetByIdAsync(int id, Expression<Func<TEntity, object>> include = null, bool disableTracking = true, CancellationToken cancellation = default);
    Task CreateAsync(TEntity entity, CancellationToken cancellation);
    Task UpdateAsync(TEntity entity, CancellationToken cancellation);
    Task DeleteAsync(TEntity entity, CancellationToken cancellation);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation);
}
