using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Identity.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<Microsoft.AspNetCore.Identity.IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "54ba4860-1c2f-4105-ba48-89221af52c21",
                UserId = "374c5f7d-82e2-43c6-941e-ccc574f05540"
            },
            new IdentityUserRole<string>
            {
                RoleId = "7cb50765-2e60-4b95-800d-6412d5fc00e7",
                UserId = "8fd55dd7-fa79-47bb-8796-74eec3407667"
            });
    }
}
