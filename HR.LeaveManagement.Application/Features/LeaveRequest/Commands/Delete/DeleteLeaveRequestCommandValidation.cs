using FluentValidation;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Delete;

public class DeleteLeaveRequestCommandValidation : AbstractValidator<DeleteLeaveRequestCommand>
{
    public DeleteLeaveRequestCommandValidation()
    {
        RuleFor(r => r.Id)
            .GreaterThan(0).WithMessage("{PropertyName} could not be zero");
    }
}