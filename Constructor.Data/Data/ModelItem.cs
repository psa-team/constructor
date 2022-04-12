using Constructor.Data.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

namespace Constructor.Data.Data;

public class ModelItem
{
    public ModelItem() { Children = new List<ModelItem>(); }
    public int Id { get; set; }
    
    public int ModelId { get; set; }
    [ForeignKey(nameof(ModelId))]
    public Model Model { get; set; }

    public int? ParentId { get; set; }
    [ForeignKey(nameof(ParentId))]
    public ModelItem Parent { get; set; }
    public List<ModelItem> Children { get; set; }

    public int PropertyId { get; set; }
    [ForeignKey(nameof(PropertyId))]
    public ReferenceEntityProperty Property { get; set; }

    public int EntityId { get; set; }
    [ForeignKey(nameof(EntityId))]
    public Entity Entity { get; set; }

    public int Sequence { get; set; }
}