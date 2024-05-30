namespace dotb.releases.repository;

using Microsoft.EntityFrameworkCore;

public class ReleasesDbContext : DbContext {
    public DbSet<ReleaseStore> Releases { get; set; }
    public DbSet<SystemsStore> Systems { get; set; }

    public DbSet<ComponentStore> Components { get; set; }

    public ReleasesDbContext(DbContextOptions<ReleasesDbContext> options) : base(options) {
    }
}
