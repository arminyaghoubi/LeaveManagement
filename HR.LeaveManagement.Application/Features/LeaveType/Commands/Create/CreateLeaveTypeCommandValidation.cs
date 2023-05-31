using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.Create;

public class CreateLeaveTypeCommandValidation : AbstractValidator<CreateLeaveTypeCommand>
{
    private readonly IGenericRepository<Domain.LeaveType> _repository;

    public CreateLeaveTypeCommandValidation(IGenericRepository<Domain.LeaveType> repository)
    {
        _repository = repository;

        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

        RuleFor(c => c.DefaultDays)
            .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1")
            .LessThan(100).WithMessage("{PropertyName} cannot exceed 100");

        RuleFor(r => r)
            .MustAsync(UniqueCheck)
            .WithMessage("Leave type already exists");
    }

    private async Task<bool> UniqueCheck(CreateLeaveTypeCommand command, CancellationToken cancellation) =>
        !await _repository.AnyAsync(l => l.Name == command.Name, cancellation);
}