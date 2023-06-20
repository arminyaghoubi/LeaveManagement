namespace HR.LeaveManagement.BlazorUI.Contracts;

public interface IAuthService
{
    Task<bool> LoginAsync(string email, string password);
    Task<bool> RegisterAsync(string firstName, string lastName, string email, string password);
    Task Logout();
}