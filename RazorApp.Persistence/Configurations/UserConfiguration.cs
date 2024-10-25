using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RazorApp.Domain;
using RazorApp.Domain.Common;
using System;
using System.Collections.Generic;

namespace RazorApp.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            // Properties
            builder.Property(au => au.FirstName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(au => au.LastName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(au => au.PhoneNumber)
                   .HasMaxLength(15);

            builder.Property(u => u.Gender)
                   .HasColumnType("int")
                   .IsRequired(false);

            builder.Property(au => au.Email)
                   .IsRequired(false);

            builder.Property(au => au.NormalizedEmail)
                   .IsRequired(false);

            builder.Property(u => u.EmailConfirmed)
                   .HasColumnName("EmailConfirmed")
                   .HasColumnType("bit");

            // Relationships
            builder.HasMany(au => au.Addresses)
                   .WithOne(a => a.ApplicationUser)
                   .HasForeignKey(a => a.ApplicationUserId)
                   .OnDelete(DeleteBehavior.Cascade);


            // Seed Admin User with Hashed Password
            var hasher = new PasswordHasher<ApplicationUser>();
            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = "69c528e1-dc6d-4319-8f52-89d608cbde7f",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    FirstName = "Admin",
                    LastName = "User",
                    Gender = Gender.Male,
                    PhoneNumber = "09137135707",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = hasher.HashPassword(null, "Admin@123")
                },
                new ApplicationUser
                {
                    Id = "d92eb081-9e8d-4b45-bdee-7285094f86a0",
                    UserName = "employee1",
                    NormalizedUserName = "EMPLOYEE1",
                    Email = "employee1@example.com",
                    NormalizedEmail = "EMPLOYEE1@EXAMPLE.COM",
                    EmailConfirmed = true,
                    FirstName = "John",
                    LastName = "Doe",
                    Gender = Gender.Male,
                    PhoneNumber = "09137135708",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = hasher.HashPassword(null, "Employee@123")
                },
                new ApplicationUser
                {
                    Id = "ba22c70f-15bb-413f-b32f-0e48b6e4c8d3",
                    UserName = "employee2",
                    NormalizedUserName = "EMPLOYEE2",
                    Email = "employee2@example.com",
                    NormalizedEmail = "EMPLOYEE2@EXAMPLE.COM",
                    EmailConfirmed = true,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Gender = Gender.Female,
                    PhoneNumber = "09137135709",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = hasher.HashPassword(null, "Employee@456")
                },
                new ApplicationUser
                {
                    Id = "ff7b46c8-daa6-4a5e-b5a7-c4d8d7a7888b",
                    UserName = "employee3",
                    NormalizedUserName = "EMPLOYEE3",
                    Email = "employee3@example.com",
                    NormalizedEmail = "EMPLOYEE3@EXAMPLE.COM",
                    EmailConfirmed = true,
                    FirstName = "Michael",
                    LastName = "Johnson",
                    Gender = Gender.Male,
                    PhoneNumber = "09137135710",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = hasher.HashPassword(null, "Employee@789")
                }
            };

            var adminUser = new ApplicationUser
            {
                Id = "69c528e1-dc6d-4319-8f52-89d608cbde7f",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "User",
                Gender = Gender.Male,
                PhoneNumber = "09137135707",
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            // Set password hash
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin@123");

            builder.HasData(adminUser);
        }
    }
}
