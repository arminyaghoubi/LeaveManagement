using AutoMapper;
using HR.LeaveManagement.BlazorUI.Services.Base;
using HR.LeaveManagement.BlazorUI.ViewModels;

namespace HR.LeaveManagement.BlazorUI.MappingProfiles;

public class LeaveTypeViewModelProfile : Profile
{
    public LeaveTypeViewModelProfile()
    {
        CreateMap<GetLeaveTypesDto, LeaveTypeViewModel>();
        CreateMap<GetLeaveTypeDetailsDto, LeaveTypeViewModel>();
        CreateMap<LeaveTypeViewModel, CreateLeaveTypeCommand>();
        CreateMap<LeaveTypeViewModel, UpdateLeaveTypeCommand>();
    }
}