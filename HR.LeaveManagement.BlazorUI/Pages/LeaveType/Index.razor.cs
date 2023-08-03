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
using Blazored.Toast.Services;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveType;

public partial class Index
{
    public string ModalClass = "";
    public bool ShowBackdrop = false;
    public string ModalDisplay = "none;";
    public LeaveTypeViewModel? DeleteItem = null;

    [Inject]
    public IToastService ToastService { get; set; }

    [Inject]
    public ILeaveTypeService LeaveTypeService { get; set; }

    [Inject]
    public ILeaveAllocationService LeaveAllocationService { get; set; }

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
        _leaveTypes = await LeaveTypeService.GetAllAsync(1, 20,CancellationToken.None);
    }

    protected void OpenDeleteModal(LeaveTypeViewModel item)
    {
        DeleteItem = item;
        ModalDisplay = "block;";
        ModalClass = "Show";
        ShowBackdrop = true;
        StateHasChanged();
    }

    protected void CloseDeleteModal()
    {
        DeleteItem = null;
        ModalDisplay = "none";
        ModalClass = "";
        ShowBackdrop = false;
        StateHasChanged();
    }

    protected async Task DeleteLeaveType()
    {
        await LeaveTypeService.DeleteAsync(DeleteItem.Id);
        await LoadLeaveTypes();
        CloseDeleteModal();
        ToastService.ShowSuccess("The deletion was successful.");
        StateHasChanged();
    }

    protected async void AllocateLeaveType(int leaveTypeId)
    {
        await LeaveAllocationService.CreateLeaveAllocationsAsync(leaveTypeId);
        ToastService.ShowInfo("The Allocation was successful.");
        StateHasChanged();
    }
}