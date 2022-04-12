using Constructor.Data.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Constructor.Data.Data;

public class EntityLink
{
    public int PropertyId { get; set; }
    [ForeignKey(nameof(PropertyId))]
    public ReferenceEntityProperty Property { get; set; }

    public int EntitySourceId { get; set; }
    [ForeignKey(nameof(EntitySourceId))]
    public Entity Source { get; set; }

    public int EntityTargetId { get; set; }
    [ForeignKey(nameof(EntityTargetId))]
    public Entity Target { get; set; }
}