using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistance;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.Create;

public class CreateLeaveAllocationCommandValidation : AbstractValidator<CreateLeaveAllocationCommand>
{
    private readonly IGenericRepository<Domain.LeaveType> _repository;

    public CreateLeaveAllocationCommandValidation(IGenericRepository<Domain.LeaveType> repository)
    {
        _repository = repository;

        RuleFor(l => l.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(LeaveTypeExist).WithMessage("{PropertypName} is not exist.");
    }

    private async Task<bool> LeaveTypeExist(int id, CancellationToken cancellation) => await _repository.AnyAsync(r => r.Id == id, cancellation);
}