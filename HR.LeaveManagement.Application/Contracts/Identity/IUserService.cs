using HR.LeaveManagement.Application.Models.Identity;

namespace HR.LeaveManagement.Application.Contracts.Identity;

public interface IUserService
{
    Task<IEnumerable<Employee>> GetEmployeesAsync();
    Task<Employee> GetEmployeeAsync(string userId);
    public string UserId { get; }
}
