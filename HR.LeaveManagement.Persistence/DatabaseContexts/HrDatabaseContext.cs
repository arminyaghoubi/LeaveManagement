using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.DatabaseContexts;

public class HrDatabaseContext : DbContext
{
    public HrDatabaseContext(DbContextOptions<HrDatabaseContext> options) : base(options)
    {
    }

    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var item in base.ChangeTracker.Entries<BaseEntity>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
        {
            item.Entity.LastModifiedDate = DateTime.Now;

            if (item.State == EntityState.Added)
                item.Entity.CreationDate = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrDatabaseContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
