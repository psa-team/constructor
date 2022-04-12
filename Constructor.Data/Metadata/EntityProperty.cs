using System.ComponentModel.DataAnnotations.Schema;

namespace Constructor.Data.Metadata;

public abstract class EntityProperty : BaseEntity
{
    public int EntityTypeId { get; set; }
    [ForeignKey(nameof(EntityTypeId))]
    public EntityType EntityType { get; set; }

    public bool IsRequired { get; set; }
    public bool IsPartOfName { get; set; }
    public int Sequence { get; set; }
}