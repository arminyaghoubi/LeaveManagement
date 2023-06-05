using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Update;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Domain.LeaveRequest> _leaveRequestRepository;

    public UpdateLeaveRequestCommandHandler(IMapper mapper, IGenericRepository<Domain.LeaveRequest> leaveRequestRepository)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
    }

    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id, cancellation: cancellationToken) ?? throw new NotFoundException(nameof(Domain.LeaveRequest), request.Id);

        UpdateLeaveRequestCommandValidation validation = new();
        var validationResult = await validation.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Request", validationResult);


        _mapper.Map(request, leaveRequest);

        await _leaveRequestRepository.UpdateAsync(leaveRequest, cancellationToken);

        return Unit.Value;
    }
}