using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DasharooAPI.Configurations.Entities
{
    public class RecordAuthorConfiguration : IEntityTypeConfiguration<RecordAuthor>
    {
        public void Configure(EntityTypeBuilder<RecordAuthor> builder)
        {
            builder
                .HasKey(x => new { x.RecordId, x.AuthorId });
            builder
                .HasOne(x => x.Record)
                .WithMany(x => x.RecordAuthors)
                .HasForeignKey(x => x.RecordId);
            builder
                .HasOne(x => x.Author)
                .WithMany(x => x.RecordAuthors)
                .HasForeignKey(x => x.AuthorId);
        }
    }
}
