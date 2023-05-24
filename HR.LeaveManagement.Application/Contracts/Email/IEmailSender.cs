using HR.LeaveManagement.Application.Models.Email;

namespace HR.LeaveManagement.Application.Contracts.Email;

public interface IEmailSender
{
    Task<bool> SendAsync(EmailMessage message);
}
