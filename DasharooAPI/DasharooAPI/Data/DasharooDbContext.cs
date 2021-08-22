using DasharooAPI.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<RecordGenre> RecordGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new VisibilityConfiguration());
            builder.ApplyConfiguration(new RecordGenreConfiguration());
            // builder.ApplyConfiguration(new RecordSupportConfiguration());
        }
    }
}
