using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.Delete;

public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
{
    private readonly IGenericRepository<Domain.LeaveAllocation> _repository;

    public DeleteLeaveAllocationCommandHandler(IGenericRepository<Domain.LeaveAllocation> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var deleteLeaveAllocation = await _repository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Domain.LeaveAllocation), request.Id);

        await _repository.DeleteAsync(deleteLeaveAllocation);

        return Unit.Value;
    }
}
