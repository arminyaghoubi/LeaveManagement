using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.Update;

public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Domain.LeaveAllocation> _repository;

    public UpdateLeaveAllocationCommandHandler(IMapper mapper, IGenericRepository<Domain.LeaveAllocation> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {


        var updateLeaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request);

        await _repository.UpdateAsync(updateLeaveAllocation,cancellationToken);

        return Unit.Value;
    }
}
