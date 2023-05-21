using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetDetails;

public class LeaveTypeDetailsQueryHandler : IRequestHandler<LeaveTypeDetailsQuery, LeaveTypeDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Domain.LeaveType> _repository;

    public LeaveTypeDetailsQueryHandler(IMapper mapper, IGenericRepository<Domain.LeaveType> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<LeaveTypeDetailsDto> Handle(LeaveTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveType = await _repository.GetByIdAsync(request.Id, cancellationToken);

        return _mapper.Map<LeaveTypeDetailsDto>(leaveType);
    }
}