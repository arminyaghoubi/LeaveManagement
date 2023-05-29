using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Models.Email;
using HR.LeaveManagement.Infrastructure.EmailService;
using HR.LeaveManagement.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) =>
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"))
        .AddTransient<IEmailSender, EmailSender>()
        .AddScoped(typeof(IApplicationLogger<>), typeof(LoggerAdapter<>));
}
