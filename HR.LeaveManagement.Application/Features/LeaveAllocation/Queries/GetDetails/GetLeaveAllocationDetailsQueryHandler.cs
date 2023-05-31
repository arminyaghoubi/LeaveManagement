using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetDetails;

public class GetLeaveAllocationDetailsQueryHandler : IRequestHandler<GetLeaveAllocationDetailsQuery, GetLeaveAllocationDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Domain.LeaveAllocation> _repository;

    public GetLeaveAllocationDetailsQueryHandler(IMapper mapper,
        IGenericRepository<Domain.LeaveAllocation> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<GetLeaveAllocationDetailsDto> Handle(GetLeaveAllocationDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _repository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Domain.LeaveAllocation),request.Id);

        return _mapper.Map<GetLeaveAllocationDetailsDto>(leaveAllocation);
    }
}