﻿using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.ChangeApproval;

public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
{
    private readonly IGenericRepository<Domain.LeaveRequest> _repository;

    public ChangeLeaveRequestApprovalCommandHandler(IGenericRepository<Domain.LeaveRequest> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
    {
        ChangeLeaveRequestApprovalCommandValidation validation = new(_repository);
        var validationResult = await validation.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Request", validationResult);

        var leaveRequest = await _repository.GetByIdAsync(request.Id, disableTracking: false, cancellation: cancellationToken) ?? throw new NotFoundException(nameof(Domain.LeaveRequest), request.Id);

        leaveRequest.Approved = request.Approved;

        await _repository.UpdateAsync(leaveRequest, cancellationToken);

        return Unit.Value;
    }
}