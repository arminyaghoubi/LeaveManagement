using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetDetails;

public class GetLeaveRequestDetailsQueryHandler : IRequestHandler<GetLeaveRequestDetailsQuery, GetLeaveRequestDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Domain.LeaveRequest> _repository;

    public GetLeaveRequestDetailsQueryHandler(IMapper mapper, IGenericRepository<Domain.LeaveRequest> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<GetLeaveRequestDetailsDto> Handle(GetLeaveRequestDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _repository.GetByIdAsync(request.Id, include: r => r.LeaveType, cancellation: cancellationToken);

        return _mapper.Map<GetLeaveRequestDetailsDto>(leaveRequest);
    }
}