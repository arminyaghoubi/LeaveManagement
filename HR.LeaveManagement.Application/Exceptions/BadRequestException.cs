using FluentValidation.Results;

namespace HR.LeaveManagement.Application.Exceptions;

public class BadRequestException : Exception
{
    public IDictionary<string, string[]> ValidationErrors { get; set; } = new Dictionary<string, string[]>();

    public BadRequestException(string message) : base(message) { }

    public BadRequestException(string message, ValidationResult validationResult) : this(message) =>
        ValidationErrors = validationResult.ToDictionary();
}