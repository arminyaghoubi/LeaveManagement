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
using HR.LeaveManagement.BlazorUI.ViewModels;
using HR.LeaveManagement.BlazorUI.Contracts;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveType;

public partial class Index
{
    public string ModalClass = "";
    public bool ShowBackdrop = false;
    public string ModalDisplay = "none;";
    public LeaveTypeViewModel? DeleteItem = null;

    [Inject]
    public ILeaveTypeService Service { get; set; }

    private List<LeaveTypeViewModel> _leaveTypes;

    public List<LeaveTypeViewModel> LeaveTypes
	{
		get { return _leaveTypes; }
	}

    protected override async Task OnInitializedAsync()
    {
        await LoadLeaveTypes();
    }

    private async Task LoadLeaveTypes()
    {
        _leaveTypes = await Service.GetAllAsync(1, 20,CancellationToken.None);
    }

    public void OpenDeleteModal(LeaveTypeViewModel item)
    {
        DeleteItem = item;
        ModalDisplay = "block;";
        ModalClass = "Show";
        ShowBackdrop = true;
        StateHasChanged();
    }

    public void CloseDeleteModal()
    {
        DeleteItem = null;
        ModalDisplay = "none";
        ModalClass = "";
        ShowBackdrop = false;
        StateHasChanged();
    }

    public async Task DeleteLeaveType()
    {
        await Service.DeleteAsync(DeleteItem.Id);
        await LoadLeaveTypes();
        CloseDeleteModal();
    }
}