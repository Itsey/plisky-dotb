using System.ComponentModel.DataAnnotations;

namespace Plisky.GlitterPortal;

public class RepoCommitCount {

    [Key]
    public int Id { get; set; }

    public int GoodCommits { get; set; }
    public int TotalCommits { get; set; }
}