using Constructor.Data.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Constructor.Data.Metadata;
public enum EntityTypeRole : byte
{
    [Description("Элемент модели")]
    Item = 0,
    [Description("Модель")]
    Model = 1,
    [Description("Справочник")]
    Dictionary = 2
}
public class EntityType : BaseEntity
{
    public EntityType() 
    {
        Children = new();
        Properties = new(); 
        Entities = new();
        Models = new();
        ImportingDomains = new();
        ReferenceProperties = new();
    }

    [Column(TypeName = "varchar")]
    [MaxLength(100)]
    [StringLength(100)]
    public string? PluralName { get; set; }

    public int DomainId { get; set; }
    [ForeignKey(nameof(DomainId))]
    public Domain Domain { get; set; }

    public int? GroupId { get; set; }
    [ForeignKey(nameof(GroupId))]
    public EntityTypeGroup Group { get; set; }

    public int? ParentId { get; set; }
    [ForeignKey(nameof(ParentId))]
    public EntityType Parent { get; set; }
    public List<EntityType> Children { get; set; }

    public EntityTypeRole Role { get; set; }

    public bool IsAbstract { get; set; }
    public bool IsMasterData { get; set; }
    public List<EntityProperty> Properties { get; set; }

    public List<Entity> Entities { get; set; }
    public List<Model> Models { get; set; }
    public List<Domain> ImportingDomains { get; set; }
    public List<ReferenceEntityProperty> ReferenceProperties { get; set; }
}