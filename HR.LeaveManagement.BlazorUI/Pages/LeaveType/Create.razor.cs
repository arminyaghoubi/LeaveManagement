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
using HR.LeaveManagement.BlazorUI.Contracts;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveType
{
    public partial class Create
    {
        public ViewModels.LeaveTypeViewModel ViewModel { get; set; }

        public string Message { get; set; }

        [Inject]
        public ILeaveTypeService LeaveTypeService { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        protected override void OnInitialized()
        {
            ViewModel = new();
        }

        protected async Task CreateHandler()
        {
            Message = string.Empty;
            var response= await LeaveTypeService.CreateAsync(ViewModel, CancellationToken.None);

            if (response.Success)
                Navigation.NavigateTo("/LeaveType/Index");
            else
                Message= response.ValidationErrors;
        }
    }
}