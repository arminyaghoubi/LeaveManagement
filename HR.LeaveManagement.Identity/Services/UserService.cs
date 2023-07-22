using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Models.Identity;
using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace HR.LeaveManagement.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _httpContext;

    public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContext)
    {
        _userManager = userManager;
        _httpContext = httpContext;
    }

    public string UserId { get => _httpContext.HttpContext?.User?.FindFirstValue("UserId"); }

    public async Task<Employee> GetEmployeeAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return new Employee
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
        };
    }

    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        return (await _userManager.GetUsersInRoleAsync(RoleNames.Employee))
            .Select(u => new Employee
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email
            });

    }
}