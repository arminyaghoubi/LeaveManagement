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
using HR.LeaveManagement.BlazorUI.Providers;

namespace HR.LeaveManagement.BlazorUI.Shared
{
    public partial class NavMenu
    {
        private bool collapseNavMenu = true;
        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        [Inject]
        public AuthenticationStateProvider AuthenticationState { get; set; }

        [Inject]
        public IAuthService AuthService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ((ApiAuthStateProvider)AuthenticationState).GetAuthenticationStateAsync();
        }

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        private void Logout()
        {
            AuthService.Logout();
        }
    }
}