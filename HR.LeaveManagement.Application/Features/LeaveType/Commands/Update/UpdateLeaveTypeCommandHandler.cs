using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.Update;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Domain.LeaveType> _repository;
    private readonly IApplicationLogger<UpdateLeaveTypeCommandHandler> _logger;

    public UpdateLeaveTypeCommandHandler(IMapper mapper, IGenericRepository<Domain.LeaveType> repository, IApplicationLogger<UpdateLeaveTypeCommandHandler> logger)
    {
        _mapper = mapper;
        _repository = repository;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        UpdateLeaveTypeCommandValidation validation = new(_repository);
        var validationResult = await validation.ValidateAsync(request);

        if (validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Domain.LeaveType), request.Id);
            throw new BadRequestException("Invalid Request", validationResult);
        }

        var updateLeaveType = _mapper.Map<Domain.LeaveType>(request);

        await _repository.UpdateAsync(updateLeaveType, cancellationToken);

        return Unit.Value;
    }
}
