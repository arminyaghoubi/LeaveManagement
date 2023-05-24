using HR.LeaveManagement.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<HrDatabaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("HrDatabaseContext")));
}
