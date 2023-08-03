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
using HR.LeaveManagement.BlazorUI.Services;
using HR.LeaveManagement.BlazorUI.Contracts;
using Blazored.Toast.Services;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveRequest
{
    public partial class Create
    {
        public LeaveRequestViewModel ViewModel { get; set; }

        public List<LeaveTypeViewModel> LeaveTypes { get; set; }

        public string Message { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public ILeaveRequestService LeaveRequestService { get; set; }

        [Inject]
        public ILeaveTypeService LeaveTypeService { get; set; }

        protected override async void OnInitialized()
        {
            ViewModel = new();
            LeaveTypes = new List<LeaveTypeViewModel>();
            await LoadLeaveTypes();
        }

        private async Task LoadLeaveTypes()
        {
            LeaveTypes = await LeaveTypeService.GetAllAsync(1, 20, CancellationToken.None);
            StateHasChanged();
        }

        protected async Task CreateHandler()
        {
            Message = string.Empty;
            var response = await LeaveRequestService.CreateAsync(ViewModel, CancellationToken.None);

            if (response.Success)
            {
                ToastService.ShowSuccess("Created Successfully");
                Navigation.NavigateTo("/LeaveRequest/Index");
            }
            else
                Message = response.ValidationErrors;
        }
    }
}