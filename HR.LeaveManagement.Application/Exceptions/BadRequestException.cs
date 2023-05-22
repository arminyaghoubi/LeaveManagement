using FluentValidation.Results;

namespace HR.LeaveManagement.Application.Exceptions;

public class BadRequestException : Exception
{
    public List<string> ValidationErrors { get; set; } = new List<string>();

    public BadRequestException(string message) : base(message)
    {
    }

    public BadRequestException(string message, ValidationResult validationResult) : this(message)
    {
        ValidationErrors.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));
    }
}