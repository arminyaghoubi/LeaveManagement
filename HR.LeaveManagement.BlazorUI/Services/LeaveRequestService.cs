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
            await AddBearerTokenToHeader();

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
        await AddBearerTokenToHeader();
        var leaveRequests = await _client.LeaveRequestAllAsync(page, pageSize, cancellation);
        List<LeaveRequestViewModel> result = null;
        return _mapper.Map<List<LeaveRequestViewModel>>(leaveRequests);
    }

    public Task<LeaveRequestViewModel> GetByIdAsync(int id, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }
}
