using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RazorApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorApp.Persistence.Configurations
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            // Table name
            builder.ToTable("States");

            // Primary key
            builder.HasKey(s => s.Id);

            // Properties
            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            // Relationships
            builder.HasMany(s => s.Addresses)
                   .WithOne(a => a.State)
                   .HasForeignKey(a => a.StateId)
                   .OnDelete(DeleteBehavior.Restrict);

            // BaseDomainEntity configuration
            builder.Property(s => s.DateCreated)
                   .IsRequired();

            builder.Property(s => s.LastModifiedDate)
                   .IsRequired();
        }
    }
}
