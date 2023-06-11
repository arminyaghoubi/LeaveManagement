using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Update;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;
    private readonly IGenericRepository<Domain.LeaveRequest> _leaveRequestRepository;
    private readonly IGenericRepository<Domain.LeaveType> _leaveTypeRepository;
    private readonly IApplicationLogger<UpdateLeaveRequestCommandHandler> _logger;

    public UpdateLeaveRequestCommandHandler(IMapper mapper,
        IEmailSender emailSender,
        IGenericRepository<Domain.LeaveRequest> leaveRequestRepository,
        IGenericRepository<Domain.LeaveType> leaveTypeRepository,
        IApplicationLogger<UpdateLeaveRequestCommandHandler> logger)
    {
        _mapper = mapper;
        _emailSender = emailSender;
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id, cancellation: cancellationToken) ?? throw new NotFoundException(nameof(Domain.LeaveRequest), request.Id);

        UpdateLeaveRequestCommandValidation validation = new(_leaveRequestRepository, _leaveTypeRepository);
        var validationResult = await validation.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Request", validationResult);

        _mapper.Map(request, leaveRequest);

        await _leaveRequestRepository.UpdateAsync(leaveRequest, cancellationToken);

        try
        {
            await _emailSender.SendAsync(
                new Models.Email.EmailMessage
                {
                    To = "Employee Email",
                    Body = "Your leave request has been updated.",
                    Subject = "Leave Request"
                });
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
        }

        return Unit.Value;
    }
}