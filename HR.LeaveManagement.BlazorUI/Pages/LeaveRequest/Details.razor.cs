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
    public partial class Details
    {
        [Parameter]
        public int Id { get; set; }

        public LeaveRequestViewModel ViewModel { get; set; }

        public string CardClass { get; set; } = string.Empty;

        [Inject]
        public ILeaveRequestService LeaveRequestService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadLeaveRequestAsync(Id);
            CardClassManage(ViewModel);
        }

        private async Task LoadLeaveRequestAsync(int id)
        {
            ViewModel = await LeaveRequestService.GetByIdAsync(id, CancellationToken.None);
        }

        private void CardClassManage(LeaveRequestViewModel viewModel)
        {
            if (viewModel.Approved is null)
            {
                CardClass = "border-warning";
            }
            else if (viewModel.Approved is true)
            {
                CardClass = "border-success";
            }
            else if (viewModel.Cancelled is true)
            {
                CardClass = "border-danger";
            }
        }

        protected async Task ApproveRequestAsync()
        {

        }

        protected async Task RejectRequestAsync()
        {

        }
    }
}