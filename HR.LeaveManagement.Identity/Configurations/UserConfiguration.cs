using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Identity.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher=new PasswordHasher<ApplicationUser>();

        builder.HasData(
            new ApplicationUser
            {
                Id = "374c5f7d-82e2-43c6-941e-ccc574f05540",
                FirstName="Armin",
                LastName="Yaghoubi",
                Email="ArminYaghoubi1@gmail.com",
                UserName= "ArminYaghoubi1@gmail.com",
                NormalizedEmail = "ArminYaghoubi1@gmail.com".ToUpper(),
                NormalizedUserName= "ArminYaghoubi1@gmail.com".ToUpper(),
                PasswordHash=hasher.HashPassword(null,"admin123"),
                EmailConfirmed =true
            },
            new ApplicationUser
            {
                Id = "8fd55dd7-fa79-47bb-8796-74eec3407667",
                FirstName = "Sara",
                LastName = "Employee",
                Email = "Sara@gmail.com",
                UserName = "Sara@gmail.com",
                NormalizedEmail = "Sara@gmail.com".ToUpper(),
                NormalizedUserName = "Sara@gmail.com".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "123"),
                EmailConfirmed = true
            });
    }
}
