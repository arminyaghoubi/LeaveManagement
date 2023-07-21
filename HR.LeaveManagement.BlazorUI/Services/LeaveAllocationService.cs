using Blazored.LocalStorage;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Services;

public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
{
    public LeaveAllocationService(IClient client, 
        ILocalStorageService localStorageService) : base(client, localStorageService)
    {
    }

    public async Task<Response<Guid>> CreateLeaveAllocationsAsync(int leaveTypeId)
    {
        try
        {
            await AddBearerTokenToHeader();
            await _client.LeaveAllocationPOSTAsync(new CreateLeaveAllocationCommand
            {
                LeaveTypeId=leaveTypeId
            });
            return new Response<Guid>();
        }
        catch (ApiException ex)
        {
            return ConvertExceptionToResponse(ex);
        }
    }
}
