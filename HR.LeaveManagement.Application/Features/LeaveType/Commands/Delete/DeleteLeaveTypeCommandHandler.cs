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
        DeleteLeaveTypeCommandValidation validation = new();
        var validationResult=await validation.ValidateAsync(request,cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Request", validationResult);

        var deleteLeaveType = await _repository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Domain.LeaveType), request.Id);

        await _repository.DeleteAsync(deleteLeaveType, cancellationToken);

        return Unit.Value;
    }
}
