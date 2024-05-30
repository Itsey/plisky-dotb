using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Plisky.GlitterPortal;

public class GdbRepository {

    [Key]
    public int Id { get; set; }

    public string? Name { get; internal set; }
    public string? Directory { get; internal set; }
    public int BranchCount { get; internal set; }
    public int RemoteBranchCount { get; internal set; }
    public string? Origin { get; internal set; }
    public string? FirstSha { get; internal set; }

    public Guid Key { get; set; }
    public DbSet<RepoCommitCount> CommitCount { get; set; }
    public DbSet<GdbFile> Files { get; set; }
}