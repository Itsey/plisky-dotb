using Microsoft.EntityFrameworkCore;

namespace Plisky.GlitterPortal;

public class GlitterDbContext : DbContext {
    public DbSet<GdbUser> Users { get; set; }
    public DbSet<GdbAuthors> Authors { get; set; }
    public DbSet<GdbRepository> Repositories { get; set; }

    public DbSet<GdbCommit> Commits { get; set; }

    public DbSet<GdbFile> Files { get; set; }

    public GlitterDbContext(DbContextOptions<GlitterDbContext> options) : base(options) {
    }
}