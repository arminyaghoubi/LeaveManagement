using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Domain.Common;
using HR.LeaveManagement.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HR.LeaveManagement.Persistence.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly HrDatabaseContext _context;
    protected readonly DbSet<TEntity> _entities;

    public GenericRepository(HrDatabaseContext context)
    {
        _context = context;
        _entities = _context.Set<TEntity>();
    }

    public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
        Expression<Func<TEntity, object>> include = null,
        Expression<Func<TEntity, object>> order = null,
        bool ascending = true,
        bool disableTracking = true,
        int page = 1,
        int pageSize = 20,
        CancellationToken cancellation = default)
    {
        var query = _entities.AsQueryable();

        if (predicate is not null)
            query = query.Where(predicate);

        if (include is not null)
            query = query.Include(include);

        if (order is not null)
            query = ascending ? query.OrderBy(order) : query.OrderByDescending(order);

        if (disableTracking)
            query = query.AsNoTracking();

        return await query.Take(pageSize).Skip((page - 1) * pageSize).ToListAsync(cancellation);
    }

    public async Task<TEntity?> GetByIdAsync(int id, bool disableTracking = true, CancellationToken cancellation = default) =>
        disableTracking ? await _entities.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id, cancellation) : await _entities.FindAsync(id, cancellation);

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation) => await _entities.AnyAsync(predicate, cancellation);

    public async Task CreateAsync(TEntity entity, CancellationToken cancellation)
    {
        await _entities.AddAsync(entity, cancellation);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellation)
    {
        _entities.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _entities.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
