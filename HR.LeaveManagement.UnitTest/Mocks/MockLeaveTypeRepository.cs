using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Domain;
using Moq;
using System.Runtime.CompilerServices;

namespace HR.LeaveManagement.UnitTest.Mocks;

public class MockLeaveTypeRepository
{
    public Mock<IGenericRepository<LeaveType>> GetLeaveTypes()
    {
        List<LeaveType> leaveTypes = new List<LeaveType>
        {
            new LeaveType
            {
                Id = 1,
                Name = "Test Vacation",
                DefaultDays = 10
            },
            new LeaveType
            {
                Id = 2,
                Name = "Test Sick",
                DefaultDays = 15
            },
            new LeaveType
            {
                Id = 3,
                Name = "Test Maternity",
                DefaultDays = 15
            },
        };

        Mock<IGenericRepository<LeaveType>> mockRepository = new();

        mockRepository.Setup(r => r.GetAsync(null,null,null,true,true,1,20,default)).ReturnsAsync(leaveTypes);

        return mockRepository;
    }
}
