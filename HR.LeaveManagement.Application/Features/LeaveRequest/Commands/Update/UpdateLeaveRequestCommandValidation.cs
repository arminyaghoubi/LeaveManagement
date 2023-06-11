using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Common;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Update;

public class UpdateLeaveRequestCommandValidation : AbstractValidator<UpdateLeaveRequestCommand>
{
    private readonly IGenericRepository<Domain.LeaveRequest> _leaveRequestRepository;
    private readonly IGenericRepository<Domain.LeaveType> _leaveTypeRepository;

    public UpdateLeaveRequestCommandValidation(IGenericRepository<Domain.LeaveRequest> leaveRequestRepository, IGenericRepository<Domain.LeaveType> leaveTypeRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;

        Include(new BaseLeaveRequesValidation(_leaveTypeRepository));

        RuleFor(l => l.Id)
            .GreaterThan(0)
            .MustAsync(LeaveRequestExist).WithMessage("{PropertyName} dose not exist.");
    }

    private async Task<bool> LeaveRequestExist(int Id, CancellationToken cancellation) =>
        await _leaveRequestRepository.AnyAsync(l => l.Id == Id, cancellation);

}