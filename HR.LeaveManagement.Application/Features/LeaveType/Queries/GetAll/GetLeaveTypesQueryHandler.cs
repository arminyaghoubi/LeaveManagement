using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAll;

public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, IEnumerable<GetLeaveTypesDto>>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Domain.LeaveType> _repository;

    public GetLeaveTypesQueryHandler(IMapper mapper,
        IGenericRepository<Domain.LeaveType> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IEnumerable<GetLeaveTypesDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
    {
        var leaveTypes = await _repository.GetAsync(page: request.Page, pageSize: request.PageSize, cancellation: cancellationToken);

        return _mapper.Map<IEnumerable<GetLeaveTypesDto>>(leaveTypes);
    }
}