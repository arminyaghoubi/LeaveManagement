using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Models.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HR.LeaveManagement.Infrastructure.EmailService;

public class EmailSender : IEmailSender
{
    private readonly EmailSettings _settings;

    public EmailSender(IOptions<EmailSettings> settings)
    {
        _settings = settings.Value;
    }

    public async Task<bool> SendAsync(EmailMessage message)
    {
        var client = new SendGridClient(_settings.ApiKey);
        var to = new EmailAddress(message.To);
        var from = new EmailAddress
        {
            Email = _settings.FromAddress,
            Name = _settings.FromName
        };

        var emailMessage = MailHelper.CreateSingleEmail(from, to, message.Subject, message.Body, message.Body);
        var response = await client.SendEmailAsync(emailMessage);

        return response.IsSuccessStatusCode;
    }
}
