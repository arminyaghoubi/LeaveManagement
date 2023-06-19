using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Identity.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "54ba4860-1c2f-4105-ba48-89221af52c21",
                Name = RoleNames.Admin,
                NormalizedName = RoleNames.Admin.ToUpper()
            },
            new IdentityRole
            {
                Id = "7cb50765-2e60-4b95-800d-6412d5fc00e7",
                Name = RoleNames.Employee,
                NormalizedName = RoleNames.Employee.ToUpper()
            });
    }
}