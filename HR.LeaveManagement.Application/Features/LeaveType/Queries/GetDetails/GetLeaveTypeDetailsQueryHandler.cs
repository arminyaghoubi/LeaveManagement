using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetDetails;

public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, GetLeaveTypeDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Domain.LeaveType> _repository;

    public GetLeaveTypeDetailsQueryHandler(IMapper mapper, IGenericRepository<Domain.LeaveType> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<GetLeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveType = await _repository.GetByIdAsync(request.Id, cancellationToken);

        return _mapper.Map<GetLeaveTypeDetailsDto>(leaveType);
    }
}