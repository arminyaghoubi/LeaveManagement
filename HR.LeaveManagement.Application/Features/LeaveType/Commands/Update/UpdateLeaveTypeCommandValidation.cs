using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistance;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.Update;

public class UpdateLeaveTypeCommandValidation : AbstractValidator<UpdateLeaveTypeCommand>
{
    private readonly IGenericRepository<Domain.LeaveType> _repository;

    public UpdateLeaveTypeCommandValidation(IGenericRepository<Domain.LeaveType> repository)
    {
        _repository = repository;

        RuleFor(c => c.Id)
            .GreaterThan(0).WithMessage("{PropertyName} could not be zero");

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

        RuleFor(r => r)
            .MustAsync(ExistCheck).WithErrorCode("{PropertyName} not found");
    }

    private async Task<bool> UniqueCheck(UpdateLeaveTypeCommand command, CancellationToken cancellation) =>
        !await _repository.AnyAsync(l => l.Name == command.Name && l.Id != command.Id, cancellation);

    private async Task<bool> ExistCheck(UpdateLeaveTypeCommand command, CancellationToken cancellation) =>
        await _repository.AnyAsync(l => l.Id == command.Id, cancellation);
}
