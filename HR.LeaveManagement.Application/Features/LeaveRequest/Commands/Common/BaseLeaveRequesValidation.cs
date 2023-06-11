using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistance;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Common;

public class BaseLeaveRequesValidation : AbstractValidator<BaseLeaveRequestDto>
{
    private readonly IGenericRepository<Domain.LeaveType> _leaveTypeRepository;

    public BaseLeaveRequesValidation(IGenericRepository<Domain.LeaveType> leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(l => l.StartDate)
            .LessThan(l => l.EndDate).WithMessage("{PropertyName} must be before {ComparisionValue}.");

        RuleFor(l => l.EndDate)
            .LessThan(l => l.StartDate).WithMessage("{PropertyName} must be after {ComparisionValue}.");

        RuleFor(l => l.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(LeaveTypeExist).WithMessage("{PropertyName} dose not exist.")
    }

    private async Task<bool> LeaveTypeExist(int leaveTypeId, CancellationToken cancellation) =>
        await _leaveTypeRepository.AnyAsync(l => l.Id == leaveTypeId, cancellation);
}