using Constructor.Data.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

namespace Constructor.Data.Data;

public class Entity : BaseEntity
{
    public Entity() 
    { 
        SourceLinks = new();
        TargetLinks = new();
    }
    public int DomainId { get; set; }
    [ForeignKey(nameof(DomainId))]
    public Domain Domain { get; set; }

    public int EntityTypeId { get; set; }
    [ForeignKey(nameof(EntityTypeId))]
    public EntityType EntityType { get; set; }

    // https://postgrespro.ru/docs/postgrespro/10/datatype-json
    // https://habr.com/ru/post/306602/
    // https://www.postgresql.org/docs/current/datatype-json.html
    [Column(TypeName = "jsonb")]
    public string? ScalarValues { get; set; }

    public List<EntityLink> SourceLinks { get; set; }
    public List<EntityLink> TargetLinks { get; set; }
}