using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Cancel;

public class CancelLeaveRequestCommandHandler : IRequestHandler<CancelLeaveRequestCommand, Unit>
{
    private readonly IGenericRepository<Domain.LeaveRequest> _repository;

    public CancelLeaveRequestCommandHandler(IGenericRepository<Domain.LeaveRequest> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(CancelLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _repository.GetByIdAsync(request.Id, disableTracking: false, cancellation: cancellationToken) ?? throw new NotFoundException(nameof(Domain.LeaveRequest), request.Id);

        leaveRequest.Cancelled = true;

        await _repository.UpdateAsync(leaveRequest, cancellationToken);

        return Unit.Value;
    }
}
