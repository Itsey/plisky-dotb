namespace dotb.releases.repository;
public class ReleaseStore {

    public int Id { get; set; }
    public Guid Key { get; set; }
    public string? ReleaseName { get; set; }

    public int ComponentId { get; set; }

    public string Version { get; set; }
    public string? Meta1 { get; set; }
    public string? Meta2 { get; set; }

    public DateTime ReleaseDate { get; set; }
    public int Environment { get; set; }

    public ICollection<ComponentStore> Components { get; set; } // Navigation property

}
