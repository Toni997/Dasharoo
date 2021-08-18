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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new VisibilityConfiguration());
            // builder.ApplyConfiguration(new RecordSupportConfiguration());
        }
    }
}
