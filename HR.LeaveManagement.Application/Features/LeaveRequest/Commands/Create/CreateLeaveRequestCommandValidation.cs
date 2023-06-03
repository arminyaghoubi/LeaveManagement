using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistance;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Create;

public class CreateLeaveRequestCommandValidation : AbstractValidator<CreateLeaveRequestCommand>
{
    public CreateLeaveRequestCommandValidation()
    {
        
    }
}