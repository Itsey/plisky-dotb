using System.ComponentModel.DataAnnotations;

namespace Plisky.GlitterPortal;

public class GdbAuthors {

    [Key]
    public int Id { get; set; }

    public string EmailIdentifier { get; set; }

    public string GeneralIdentifier { get; set; }

    public string Scope { get; set; }
}