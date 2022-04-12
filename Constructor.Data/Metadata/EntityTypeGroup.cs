using System.ComponentModel.DataAnnotations.Schema;

namespace Constructor.Data.Metadata;

public class EntityTypeGroup : BaseEntity
{
    public EntityTypeGroup() { EntityTypes = new(); }

    public int DomainId { get; set; }
    [ForeignKey(nameof(DomainId))]
    public Domain Domain { get; set; }

    public List<EntityType> EntityTypes { get; set; }
}