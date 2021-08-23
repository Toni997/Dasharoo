using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DasharooAPI.Configurations.Entities
{
    public class RecordSupporterConfiguration : IEntityTypeConfiguration<RecordSupporter>
    {
        public void Configure(EntityTypeBuilder<RecordSupporter> builder)
        {
            builder
                .HasKey(x => new { x.RecordId, x.SupporterId });
            builder
                .HasOne(x => x.Record)
                .WithMany(x => x.RecordSupporters)
                .HasForeignKey(x => x.RecordId);
            builder
                .HasOne(x => x.Supporter)
                .WithMany(x => x.RecordSupporters)
                .HasForeignKey(x => x.SupporterId);
        }
    }
}
