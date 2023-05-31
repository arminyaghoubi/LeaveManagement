using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.Create;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetAll;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.MappingProfiles;

public class LeaveAllocationProfile : Profile
{
    public LeaveAllocationProfile()
    {
        CreateMap<LeaveAllocation, GetLeaveAllocationDto>().ReverseMap();
        CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
    }
}