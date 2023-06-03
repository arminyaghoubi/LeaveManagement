using FluentValidation;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.Delete;

public class DeleteLeaveAllocationCommandValidation : AbstractValidator<DeleteLeaveAllocationCommand>
{
    public DeleteLeaveAllocationCommandValidation()
    {
        RuleFor(l => l.Id)
            .GreaterThan(0).WithMessage("{PropertyName} is not found");
    }
}