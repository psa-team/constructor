using Constructor.Data.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

namespace Constructor.Data.Data;

public class Model
{
    public Model() { Items = new List<ModelItem>(); }

    public int Id { get; set; }

    public int DomainId { get; set; }
    [ForeignKey(nameof(DomainId))]
    public Domain Domain { get; set; }

    public int EntityTypeId { get; set; }
    [ForeignKey(nameof(EntityTypeId))]
    public EntityType EntityType { get; set; }

    public int RootEntityId { get; set; }
    [ForeignKey(nameof(RootEntityId))]
    public Entity RootEntity { get; set; }

    public List<ModelItem> Items { get; set; }
}