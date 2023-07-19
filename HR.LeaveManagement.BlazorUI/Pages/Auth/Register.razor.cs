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

namespace HR.LeaveManagement.BlazorUI.Pages.Auth
{
    public partial class Register
    {
        public RegisterViewModel ViewModel { get; set; }

        public string Message { get; set; }

        [Inject]
        public IAuthService AuthService { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        protected override void OnInitialized()
        {
            ViewModel = new();
        }

        protected async Task RegisterHandle()
        {
            Message = string.Empty;
            if (await AuthService.RegisterAsync(ViewModel.FirstName, ViewModel.LastName, ViewModel.Email, ViewModel.Password))
            {
                Navigation.NavigateTo("/Login");
            }
            else
            {
                Message = "Register failed!";
            }
        }
    }
}