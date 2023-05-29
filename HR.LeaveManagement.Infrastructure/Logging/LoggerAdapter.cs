using HR.LeaveManagement.Application.Contracts.Logging;
using Microsoft.Extensions.Logging;

namespace HR.LeaveManagement.Infrastructure.Logging;

public class LoggerAdapter<T> : IApplicationLogger<T>
{
    private readonly ILogger _logger;

    public LoggerAdapter(ILoggerFactory loggerFactory) => _logger = loggerFactory.CreateLogger<T>();

    public void LogInformation(string message, params object[] args) => _logger.LogInformation(message, args);

    public void LogWarning(string message, params object[] args) => _logger.LogWarning(message, args);
}
