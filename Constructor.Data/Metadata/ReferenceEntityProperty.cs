using Constructor.Data.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Constructor.Data.Metadata;
public enum ReferencePropertyKind : byte
{
    [Description("Ссылка")]
    Link = 0,
    [Description("Элемент модели")]
    Node = 1,
}
public enum ReferenceDeleteMode : byte
{
    /// <summary>
    /// Блокировка удаления сущности при наличии на нее ссылок
    /// </summary>
    [Description("Блокировка удаления")]
    Lock = 0,
    /// <summary>
    /// Удаление ссылок на удаляемую сущность
    /// </summary>
    [Description("Удаление ссылки")]
    SetNull = 1,
    /// <summary>
    /// Удаление сущности при удалении другой сущности, на которую установлена ссылка
    /// </summary>
    [Description("Удаление сущности")]
    Cascade = 2,
}
public class ReferenceEntityProperty : EntityProperty
{
    public ReferenceEntityProperty()
    {
        EntityLinks = new();
        ModelItems = new();
    }
    public int ValueTypeId { get; set; }
    [ForeignKey(nameof(ValueTypeId))]
    public EntityType ValueType { get; set; }

    public bool IsSet { get; set; }
    public ReferencePropertyKind ReferenceKind { get; set; }
    public ReferenceDeleteMode DeleteMode { get; set; }

    public List<EntityLink> EntityLinks { get; set; }
    public List<ModelItem> ModelItems { get; set; }
}