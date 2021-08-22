using DasharooAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DasharooAPI.Configurations.Entities
{
    public class RecordGenreConfiguration : IEntityTypeConfiguration<RecordGenre>
    {
        public void Configure(EntityTypeBuilder<RecordGenre> builder)
        {
            builder
                .HasKey(x => new { x.RecordId, x.GenreId });
            builder
                .HasOne(x => x.Record)
                .WithMany(x => x.RecordGenres)
                .HasForeignKey(x => x.RecordId);
            builder
                .HasOne(x => x.Genre)
                .WithMany(x => x.RecordGenres)
                .HasForeignKey(x => x.GenreId);
        }
    }
}
