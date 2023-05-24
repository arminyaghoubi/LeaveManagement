using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Persistence.Configurations;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(70);

        builder.HasData(
            new LeaveType
            {
                Id = 1,
                Name = "Vacation",
                DefaultDays = 10,
                CreationDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
            });
    }
}
