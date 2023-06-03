using FluentValidation;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Update;

public class UpdateLeaveRequestCommandValidation : AbstractValidator<UpdateLeaveRequestCommand>
{
    public UpdateLeaveRequestCommandValidation()
    {
        
    }
}