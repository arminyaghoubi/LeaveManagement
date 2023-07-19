using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.BlazorUI.ViewModels;

public class LoginViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}