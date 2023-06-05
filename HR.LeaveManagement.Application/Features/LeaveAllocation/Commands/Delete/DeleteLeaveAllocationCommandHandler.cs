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
        DeleteLeaveAllocationCommandValidation validation = new();
        var validationResult = await validation.ValidateAsync(request);

        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Request", validationResult);

        var deleteLeaveAllocation = await _repository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Domain.LeaveAllocation), request.Id);

        await _repository.DeleteAsync(deleteLeaveAllocation,cancellationToken);

        return Unit.Value;
    }
}
