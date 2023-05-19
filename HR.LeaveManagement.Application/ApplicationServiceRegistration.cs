using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HR.LeaveManagement.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
        services.AddAutoMapper(Assembly.GetExecutingAssembly())
        .AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
}
