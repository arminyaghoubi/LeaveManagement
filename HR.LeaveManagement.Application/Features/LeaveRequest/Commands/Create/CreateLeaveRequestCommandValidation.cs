using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Common;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Create;

public class CreateLeaveRequestCommandValidation : AbstractValidator<CreateLeaveRequestCommand>
{
    private readonly IGenericRepository<Domain.LeaveType> _leaveTypeRepository;

    public CreateLeaveRequestCommandValidation(IGenericRepository<Domain.LeaveType> leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        Include(new BaseLeaveRequesValidation(_leaveTypeRepository));
    }
}