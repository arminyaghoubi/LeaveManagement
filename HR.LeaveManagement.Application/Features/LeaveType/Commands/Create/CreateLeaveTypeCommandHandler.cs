using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.Create;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Domain.LeaveType> _repository;

    public CreateLeaveTypeCommandHandler(IMapper mapper, IGenericRepository<Domain.LeaveType> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        CreateLeaveTypeCommandValidation validation = new(_repository);
        var validationResult = await validation.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Request", validationResult);

        var newLeaveType = _mapper.Map<Domain.LeaveType>(request);

        await _repository.CreateAsync(newLeaveType, cancellationToken);

        return newLeaveType.Id;
    }
}