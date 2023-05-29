using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistance;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAll;

public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, IEnumerable<GetLeaveTypesDto>>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Domain.LeaveType> _repository;
    private readonly IApplicationLogger<GetLeaveTypesQueryHandler> _logger;

    public GetLeaveTypesQueryHandler(IMapper mapper,
        IGenericRepository<Domain.LeaveType> repository,
        IApplicationLogger<GetLeaveTypesQueryHandler> logger)
    {
        _mapper = mapper;
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<GetLeaveTypesDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
    {
        var leaveTypes = await _repository.GetAsync(page: request.Page, pageSize: request.PageSize, cancellation: cancellationToken);

        _logger.LogInformation("Get Leave Types from Database Successfully");

        return _mapper.Map<IEnumerable<GetLeaveTypesDto>>(leaveTypes);
    }
}