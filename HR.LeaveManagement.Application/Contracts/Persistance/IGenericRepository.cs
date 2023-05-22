using HR.LeaveManagement.Domain.Common;
using System.Linq.Expressions;

namespace HR.LeaveManagement.Application.Contracts.Persistance;

public interface IGenericRepository<T>
    where T : BaseEntity
{
    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
        Expression<Func<T, object>> include = null,
        Expression<Func<T, object>> order = null,
        bool ascending = true,
        int page = 1,
        int pageSize = 20,
        CancellationToken cancellation = default);
    Task<T> GetByIdAsync(int id, CancellationToken cancellation);
    Task<T> CreateAsync(T entity, CancellationToken cancellation);
    Task UpdateAsync(T entity, CancellationToken cancellation);
    Task DeleteAsync(T entity, CancellationToken cancellation);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellation);
}
