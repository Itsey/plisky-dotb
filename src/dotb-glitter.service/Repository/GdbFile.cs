using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Plisky.GlitterPortal;

public class GdbFile {

    [Key]
    public int Id { get; set; }

    public string Filename { get; set; }
    public DbSet<GdbAuthors> Authors { get; set; }

    public GdbFile() {
    }
}