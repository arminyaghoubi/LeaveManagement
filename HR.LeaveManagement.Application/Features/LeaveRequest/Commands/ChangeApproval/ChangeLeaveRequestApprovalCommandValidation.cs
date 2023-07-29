using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistance;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.ChangeApproval;

public class ChangeLeaveRequestApprovalCommandValidation : AbstractValidator<ChangeLeaveRequestApprovalCommand>
{
    private readonly IGenericRepository<Domain.LeaveRequest> _repository;

    public ChangeLeaveRequestApprovalCommandValidation(IGenericRepository<Domain.LeaveRequest> repository)
    {
        _repository = repository;

        RuleFor(l => l.Id)
            .GreaterThan(0)
            .MustAsync(LeaveRequestExist).WithMessage("{PropertyName} dose not exist.");
    }

    private async Task<bool> LeaveRequestExist(int id, CancellationToken cancellation) =>
        await _repository.AnyAsync(r => r.Id == id, cancellation);
}