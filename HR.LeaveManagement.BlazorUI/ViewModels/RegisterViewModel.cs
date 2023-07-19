using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.BlazorUI.ViewModels;

public class RegisterViewModel
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string FirstName { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; }
}