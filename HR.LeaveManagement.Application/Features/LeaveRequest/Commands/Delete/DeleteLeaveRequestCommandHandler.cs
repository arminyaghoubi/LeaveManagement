using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Delete;

public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, Unit>
{
    private readonly IGenericRepository<Domain.LeaveRequest> _repository;

    public DeleteLeaveRequestCommandHandler(IGenericRepository<Domain.LeaveRequest> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        DeleteLeaveRequestCommandValidation validation = new();
        var validationResult = await validation.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Request", validationResult);

        var deleteLeaveRequest = await _repository.GetByIdAsync(request.Id, cancellation: cancellationToken) ?? throw new NotFoundException(nameof(Domain.LeaveRequest), request.Id);

        await _repository.DeleteAsync(deleteLeaveRequest, cancellationToken);

        return Unit.Value;
    }
}
