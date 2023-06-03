using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistance;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.Update;

public class UpdateLeaveAllocationCommandValidation : AbstractValidator<UpdateLeaveAllocationCommand>
{
    private readonly IGenericRepository<Domain.LeaveAllocation> _leaveAllocationRepository;
    private readonly IGenericRepository<Domain.LeaveType> _leaveTypeRepository;

    public UpdateLeaveAllocationCommandValidation(IGenericRepository<Domain.LeaveAllocation> leaveAllocationRepository,
        IGenericRepository<Domain.LeaveType> leaveTypeRepository)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(l => l.NumberOfDays)
            .GreaterThan(1).WithMessage("{PropertyName} cannot be less than {ComparisonValue}");

        RuleFor(l => l.Period)
            .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}");

        RuleFor(l => l.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(LeaveTypeExist).WithMessage("{PropertypName} is not exist.");

        RuleFor(l => l.Id)
            .GreaterThan(0)
            .MustAsync(LeaveAllocationExist).WithMessage("{PropertyName} is not found");
    }

    private Task<bool> LeaveAllocationExist(int id, CancellationToken cancellation) => _leaveAllocationRepository.AnyAsync(r => r.Id == id, cancellation);

    private async Task<bool> LeaveTypeExist(int id, CancellationToken cancellation) => await _leaveTypeRepository.AnyAsync(r => r.Id == id, cancellation);
}