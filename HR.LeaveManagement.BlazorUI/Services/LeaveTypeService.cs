using AutoMapper;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Services.Base;
using HR.LeaveManagement.BlazorUI.ViewModels;

namespace HR.LeaveManagement.BlazorUI.Services;

public class LeaveTypeService : BaseHttpService, ILeaveTypeService
{
    private readonly IMapper _mapper;

    public LeaveTypeService(IClient client, IMapper mapper) : base(client)
    {
        _mapper = mapper;
    }

    public async Task<List<LeaveTypeViewModel>> GetAllAsync(int? page, int? pageSize, CancellationToken cancellation)
    {
        var leaveTypes = await _client.LeaveTypeAllAsync(page, pageSize, cancellation);
        return _mapper.Map<List<LeaveTypeViewModel>>(leaveTypes);
    }

    public async Task<LeaveTypeViewModel> GetByIdAsync(int id, CancellationToken cancellation)
    {
        var leaveType = await _client.LeaveTypeGETAsync(id, cancellation);
        return _mapper.Map<LeaveTypeViewModel>(leaveType);
    }

    public async Task<Response<Guid>> CreateAsync(LeaveTypeViewModel leaveType, CancellationToken cancellation)
    {
        try
        {
            var command = _mapper.Map<CreateLeaveTypeCommand>(leaveType);

            await _client.LeaveTypePOSTAsync(command, cancellation);

            return new Response<Guid>
            {
                Success = true,
            };
        }
        catch (ApiException ex)
        {
            return ConvertExceptionToResponse(ex);
        }
    }

    public async Task<Response<Guid>> UpdateAsync(LeaveTypeViewModel leaveType, CancellationToken cancellation)
    {
        try
        {
            var command = _mapper.Map<UpdateLeaveTypeCommand>(leaveType);

            await _client.LeaveTypePUTAsync(command, cancellation);

            return new Response<Guid>
            {
                Success = true,
            };
        }
        catch (ApiException ex)
        {
            return ConvertExceptionToResponse(ex);
        }
    }

    public async Task<Response<Guid>> DeleteAsync(int id, CancellationToken cancellation)
    {
        try
        {
            await _client.LeaveTypeDELETEAsync(id, cancellation);

            return new Response<Guid>
            {
                Success = true,
            };
        }
        catch (ApiException ex)
        {
            return ConvertExceptionToResponse(ex);
        }
    }
}