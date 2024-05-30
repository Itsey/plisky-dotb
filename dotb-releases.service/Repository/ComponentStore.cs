namespace dotb.releases.repository;

public class ComponentStore {
    public int Id { get; set; }
    public int SystemsStoreId { get; set; } // Foreign Key
    public ICollection<ReleaseStore> Releases { get; set; } // Navigation property
    public Guid Key { get; set; }
    public string ComponentName { get; set; }
    public string? Meta1 { get; set; }


}
