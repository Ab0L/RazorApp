using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RazorApp.Persistence.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new[]
            {
                new IdentityUserRole<string>
                {
                    UserId = "69c528e1-dc6d-4319-8f52-89d608cbde7f",
                    RoleId = "03553446-a2b4-4bad-b38b-ebb4c6a86852"
                },
                new IdentityUserRole<string>
                {
                    UserId = "91f1f9c6-4a45-426e-8128-5fbe0e98ef23",
                    RoleId = "609effb8-a2d2-49b9-8347-fd74afb2b8f4"
                },
                new IdentityUserRole<string>
                {
                    UserId = "b1c52c1e-46c7-47c2-b1b3-82ab41ee6e19",
                    RoleId = "609effb8-a2d2-49b9-8347-fd74afb2b8f4"
                },
                new IdentityUserRole<string>
                {
                    UserId = "a68f9173-d745-49d0-9c62-78c5b124da74",
                    RoleId = "609effb8-a2d2-49b9-8347-fd74afb2b8f4"
                }
            });
        }
    }
}
