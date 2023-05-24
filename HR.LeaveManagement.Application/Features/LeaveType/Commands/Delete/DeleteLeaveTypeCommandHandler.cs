using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.Delete;

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    private readonly IGenericRepository<Domain.LeaveType> _repository;

    public DeleteLeaveTypeCommandHandler(IMapper mapper, IGenericRepository<Domain.LeaveType> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var deleteLeaveType = await _repository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Domain.LeaveType), request.Id);

        await _repository.DeleteAsync(deleteLeaveType);

        return Unit.Value;
    }
}
