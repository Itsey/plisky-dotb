using System.ComponentModel.DataAnnotations;

namespace Plisky.GlitterPortal;

public class GdbUser {

    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
    public string DisplayName { get; set; }
}