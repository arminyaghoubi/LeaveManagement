using AutoMapper;
using Blazored.LocalStorage;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Services.Base;
using HR.LeaveManagement.BlazorUI.ViewModels;

namespace HR.LeaveManagement.BlazorUI.Services;

public class LeaveRequestService : BaseHttpService, ILeaveRequestService
{
    private readonly IMapper _mapper;

    public LeaveRequestService(IClient client,
        ILocalStorageService localStorageService,
        IMapper mapper) : base(client, localStorageService)
    {
        _mapper = mapper;
    }

    public async Task<Response<Guid>> CreateAsync(LeaveRequestViewModel leaveRequest, CancellationToken cancellation)
    {
        try
        {
            var command = _mapper.Map<CreateLeaveRequestCommand>(leaveRequest);

            await _client.LeaveRequestPOSTAsync(command, cancellation);

            return new Response<Guid>
            {
                Success = true
            };
        }
        catch (ApiException ex)
        {
            return ConvertExceptionToResponse(ex);
        }
    }

    public async Task<List<LeaveRequestViewModel>> GetAllAsync(int? page, int? pageSize, CancellationToken cancellation)
    {
        var leaveRequests = await _client.LeaveRequestAllAsync(page, pageSize, cancellation);
        return _mapper.Map<List<LeaveRequestViewModel>>(leaveRequests);
    }

    public async Task<LeaveRequestViewModel> GetByIdAsync(int id, CancellationToken cancellation)
    {
        var leaveRequest = await _client.LeaveRequestGETAsync(id, cancellation);
        return _mapper.Map<LeaveRequestViewModel>(leaveRequest);
    }

    public ReportLeaveRequestViewModel GetReportLeaveRequest(IEnumerable<LeaveRequestViewModel> leaveRequest) =>
        new ReportLeaveRequestViewModel
        {
            TotalRequests = leaveRequest.Count(),
            ApprovedRequests = leaveRequest.Count(l => l.Approved is true),
            PendingRequests = leaveRequest.Count(l => l.Cancelled is false && l.Approved is null),
            RejectedRequests = leaveRequest.Count(l => l.Approved is false)
        };

    public async Task<Response<Guid>> ChangeApprovalAsync(int id, bool approved, CancellationToken cancellation)
    {
        try
        {
            await _client.ChangeApprovalAsync(new ChangeLeaveRequestApprovalCommand
            {
                Id = id,
                Approved = approved
            }, cancellation);

            return new Response<Guid>
            {
                Success = true
            };
        }
        catch (ApiException ex)
        {
            return ConvertExceptionToResponse(ex);
        }
    }
}
