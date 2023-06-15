using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace HR.LeaveManagement.IntegrationTest;

public class HrDatabaseContextTests
{
    private readonly HrDatabaseContext _context;

    public HrDatabaseContextTests()
    {
        var options=new DbContextOptionsBuilder<HrDatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        _context = new HrDatabaseContext(options);
    }

    [Fact]
    public async void Save_set_created_date()
    {
        // Arrange
        var leaveType = new LeaveType
        {
            Id = 1,
            DefaultDays = 10,
            Name = "Test Vacation"
        };

        // Act
        await _context.LeaveTypes.AddAsync(leaveType);
        await _context.SaveChangesAsync();

        // Assert
        leaveType.CreationDate.ShouldNotBeNull();
    }

    [Fact]
    public async void Save_set_modified_date()
    {
        // Arrange
        // Arrange
        var leaveType = new LeaveType
        {
            Id = 1,
            DefaultDays = 10,
            Name = "Test Vacation"
        };

        // Act
        await _context.LeaveTypes.AddAsync(leaveType);
        await _context.SaveChangesAsync();

        // Assert
        leaveType.LastModifiedDate.ShouldNotBeNull();
    }
}