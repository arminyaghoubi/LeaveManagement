using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetAll;

public class GetLeaveRequestQueryHandler : IRequestHandler<GetLeaveRequestQuery, IEnumerable<GetLeaveRequestDto>>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Domain.LeaveRequest> _repository;

    public GetLeaveRequestQueryHandler(IMapper mapper, IGenericRepository<Domain.LeaveRequest> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IEnumerable<GetLeaveRequestDto>> Handle(GetLeaveRequestQuery request, CancellationToken cancellationToken)
    {
        var leaveRequests = await _repository.GetAsync(include: r => r.LeaveType, page: request.Page, pageSize: request.PageSize, cancellation: cancellationToken);

        return _mapper.Map<IEnumerable<GetLeaveRequestDto>>(leaveRequests);
    }
}