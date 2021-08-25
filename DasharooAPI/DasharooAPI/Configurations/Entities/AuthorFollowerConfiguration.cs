using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DasharooAPI.Configurations.Entities
{
    public class AuthorFollowerConfiguration : IEntityTypeConfiguration<AuthorFollower>
    {
        public void Configure(EntityTypeBuilder<AuthorFollower> builder)
        {
            builder
                .HasKey(x => new { x.AuthorId, x.FollowerId });
            builder
                .HasOne(x => x.Author)
                .WithMany(x => x.Followers)
                .HasForeignKey(x => x.AuthorId);
            builder
                .HasOne(x => x.Follower)
                .WithMany(x => x.Followings)
                .HasForeignKey(x => x.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
