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
    public class UserSummaryConfiguration : IEntityTypeConfiguration<UserSummary>
    {
        public void Configure(EntityTypeBuilder<UserSummary> builder)
        {
            builder.ToTable("UserSummaries");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).IsRequired();
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.CreatedAt).IsRequired();
            builder.Property(u => u.ModifiedAt);

            builder.HasIndex(u => u.UserName).IsUnique();

            builder
                .HasMany(u => u.Followers)
                .WithOne(f => f.Followed)
                .HasForeignKey(f => f.FollowedId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(u => u.Following)
                .WithOne(f => f.Follower)
                .HasForeignKey(f => f.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(u => u.Subscriptions)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
