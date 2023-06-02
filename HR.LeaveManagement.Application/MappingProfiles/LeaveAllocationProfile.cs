using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.Create;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.Update;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetAll;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetDetails;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.MappingProfiles;

public class LeaveAllocationProfile : Profile
{
    public LeaveAllocationProfile()
    {
        CreateMap<LeaveAllocation, GetLeaveAllocationDto>().ReverseMap();
        CreateMap<LeaveAllocation, GetLeaveAllocationDetailsDto>();
        CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
        CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
    }
}