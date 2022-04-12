using Constructor.Data.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Constructor.Data.Metadata;
public class Domain : BaseEntity
{
    public Domain() 
    {
        Children = new();
        EntityTypeGroups = new();
        EntityTypes = new(); 
        ImportedTypes = new();
        Entities = new();
        Models = new();
    }

    public Guid? ComponentId { get; set; }
    public bool IsProgram => ComponentId != null;
    
    public int? ParentId { get; set; }
    [ForeignKey(nameof(ParentId))]
    public Domain Parent { get; set; }
    public List<Domain> Children { get; set; }
    
    public List<EntityTypeGroup> EntityTypeGroups { get; set; }
    public List<EntityType> EntityTypes { get; set; }
    public List<EntityType> ImportedTypes { get; set; }
    public List<Entity> Entities { get; set; }
    public List<Model> Models { get; set; }
}