using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DasharooAPI.Configurations.Entities
{
    public class VisibilityConfiguration : IEntityTypeConfiguration<Visibility>
    {
        public void Configure(EntityTypeBuilder<Visibility> builder)
        {
            builder.HasData(
                new Visibility
                {
                    Id = 1,
                    Name = "Public"
                },
                new Visibility
                {
                    Id = 2,
                    Name = "Private"
                },
                new Visibility
                {
                    Id = 3,
                    Name = "Unlisted"
                },
                new Visibility
                {
                    Id = 4,
                    Name = "Scheduled"
                }
            );
        }
    }
}