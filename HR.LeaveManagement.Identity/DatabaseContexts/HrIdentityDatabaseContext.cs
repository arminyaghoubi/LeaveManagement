using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HR.LeaveManagement.Identity.DatabaseContexts;

public class HrIdentityDatabaseContext : IdentityDbContext<ApplicationUser>
{
    public HrIdentityDatabaseContext(DbContextOptions<HrIdentityDatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
