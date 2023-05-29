namespace HR.LeaveManagement.Application.Contracts.Logging;

public interface IApplicationLogger<T>
{
    void LogInformation(string message,params object[] args);
    void LogWarning(string message, params object[] args);
}
