using Blazored.LocalStorage;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Services;

public class LeaveRequestService : BaseHttpService, ILeaveRequestService
{
    public LeaveRequestService(IClient client, 
        ILocalStorageService localStorageService) : base(client, localStorageService)
    {
    }
}
