using AutoMapper.Configuration;
using DasharooAPI.Configurations.Entities;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Cms;

namespace DasharooAPI.Data
{
    public class DasharooDbContext : IdentityDbContext<User>
    {
        public DasharooDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Playlist> RecordGenre { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RecordGenre>()
                .HasKey(x => new { x.RecordId, x.GenreId });
            builder.Entity<RecordGenre>()
                .HasOne(x => x.Record)
                .WithMany(x => x.Genres)
                .HasForeignKey(x => x.RecordId);
            builder.Entity<RecordGenre>()
                .HasOne(x => x.Genre)
                .WithMany(x => x.Records)
                .HasForeignKey(x => x.GenreId);



            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new VisibilityConfiguration());
            // builder.ApplyConfiguration(new RecordSupportConfiguration());
        }
    }
}
