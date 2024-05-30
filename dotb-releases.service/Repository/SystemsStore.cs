namespace dotb.releases.repository;
public class SystemsStore {
    public int Id { get; set; }
    public Guid Key { get; set; }
    public string SystemsName { get; set; }
    public string? Owner { get; set; }
    public string? ExternalIdentifier { get; set; }
    public string? Meta1 { get; set; }
    public string? Meta2 { get; set; }
    public ICollection<ComponentStore> Components { get; set; } // Navigation property
}
