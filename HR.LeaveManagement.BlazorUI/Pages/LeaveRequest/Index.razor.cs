using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using HR.LeaveManagement.BlazorUI;
using HR.LeaveManagement.BlazorUI.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using HR.LeaveManagement.BlazorUI.ViewModels;
using HR.LeaveManagement.BlazorUI.Contracts;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveRequest
{
    public partial class Index
    {
        public List<LeaveRequestViewModel> LeaveRequests { get; set; }

        [Inject]
        public ILeaveRequestService LeaveRequestService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadLeaveRequestsAsync();
        }

        private async Task LoadLeaveRequestsAsync()
        {
            LeaveRequests = await LeaveRequestService.GetAllAsync(1, 20, CancellationToken.None);
        }
    }
}