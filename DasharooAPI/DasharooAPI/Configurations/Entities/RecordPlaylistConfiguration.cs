using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DasharooAPI.Configurations.Entities
{
    public class RecordPlaylistConfiguration : IEntityTypeConfiguration<RecordPlaylist>
    {
        public void Configure(EntityTypeBuilder<RecordPlaylist> builder)
        {
            builder
                .HasKey(x => new { x.RecordId, x.PlaylistId });
            builder
                .HasOne(x => x.Record)
                .WithMany(x => x.RecordPlaylists)
                .HasForeignKey(x => x.RecordId);
            builder
                .HasOne(x => x.Playlist)
                .WithMany(x => x.RecordPlaylists)
                .HasForeignKey(x => x.PlaylistId);
        }
    }
}
