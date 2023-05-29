using FluentValidation;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.Delete;

public class DeleteLeaveTypeCommandValidation : AbstractValidator<DeleteLeaveTypeCommand>
{
    public DeleteLeaveTypeCommandValidation()
    {
        RuleFor(d => d.Id)
            .GreaterThan(0).WithMessage("{PropertyName} could not be zero");
    }
}