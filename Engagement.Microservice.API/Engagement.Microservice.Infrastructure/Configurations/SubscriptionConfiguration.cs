using Engagement.Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engagement.Microservice.Infrastructure.Configurations
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("Subscriptions");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id).IsRequired();
            builder.Property(s => s.UserId).IsRequired();
            builder.Property(s => s.PlanName).IsRequired().HasMaxLength(200);
            builder.Property(s => s.StartedAt).IsRequired();
            builder.Property(s => s.ExpiresAt).IsRequired();
            builder.Property(s => s.IsActive).IsRequired();
            builder.Property(s => s.CreatedAt).IsRequired();
            builder.Property(s => s.ModifiedAt);

            builder
                .HasOne(s => s.User)
                .WithMany(u => u.Subscriptions)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
