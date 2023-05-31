using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.Create;

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Domain.LeaveAllocation> _repository;

    public CreateLeaveAllocationCommandHandler(IMapper mapper,
        IGenericRepository<Domain.LeaveAllocation> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {

        var newLeaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request);

        await _repository.CreateAsync(newLeaveAllocation, cancellationToken);

        return newLeaveAllocation.Id;
    }
}