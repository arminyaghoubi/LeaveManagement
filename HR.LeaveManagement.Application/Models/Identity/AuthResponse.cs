namespace HR.LeaveManagement.Application.Models.Identity;

public class AuthResponse
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string AccessToken { get; set; }
}
