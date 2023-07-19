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
    public partial class Details
    {
        public ViewModels.LeaveTypeViewModel ViewModel { get; set; }

        [Parameter]
        public int Id { get; set; }

        [Inject]
        public ILeaveTypeService LeaveTypeService { get; set; }

        public Details()
        {
            ViewModel = new();
        }

        protected override async Task OnInitializedAsync()
        {
            ViewModel = await LeaveTypeService.GetByIdAsync(Id, CancellationToken.None);
        }
    }
}