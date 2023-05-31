using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistance;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetAll;

public class GetLeaveAllocationQueryHandler : IRequestHandler<GetLeaveAllocationQuery, IEnumerable<GetLeaveAllocationDto>>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Domain.LeaveAllocation> _repository;
    private readonly IApplicationLogger<GetLeaveAllocationQueryHandler> _logger;

    public GetLeaveAllocationQueryHandler(IMapper mapper,
        IGenericRepository<Domain.LeaveAllocation> repository,
        IApplicationLogger<GetLeaveAllocationQueryHandler> logger)
    {
        _mapper = mapper;
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<GetLeaveAllocationDto>> Handle(GetLeaveAllocationQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocations = await _repository.GetAsync(page: request.Page, pageSize: request.PageSize, cancellation: cancellationToken);

        _logger.LogInformation("Get Leave Allocations from Database Successfully");

        return _mapper.Map<IEnumerable<GetLeaveAllocationDto>>(leaveAllocations);
    }
}