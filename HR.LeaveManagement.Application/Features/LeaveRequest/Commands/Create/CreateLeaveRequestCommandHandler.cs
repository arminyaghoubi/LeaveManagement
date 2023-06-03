using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Create;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Domain.LeaveRequest> _leaveRequestRepository;

    public CreateLeaveRequestCommandHandler(IMapper mapper, IGenericRepository<Domain.LeaveRequest> leaveRequestRepository)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
    }

    public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        CreateLeaveRequestCommandValidation validation = new();
        var validationResult = await validation.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Request", validationResult);

        var newLeaveRequest = _mapper.Map<Domain.LeaveRequest>(request);

        await _leaveRequestRepository.CreateAsync(newLeaveRequest, cancellationToken);

        return newLeaveRequest.Id;
    }
}
