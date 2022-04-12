using System.ComponentModel;

namespace Constructor.Data.Metadata;
public enum ScalarValueType : byte
{
    [Description("Строка")]
    String = 0,
    [Description("Текст")]
    Text = 1,
    [Description("Логическое")]
    Boolean = 2,
    [Description("Целое число")]
    Integer = 3,
    [Description("Десятичное число")]
    Decimal = 4,
    [Description("Дата")]
    Date = 5,
    [Description("Время")]
    Time = 6,
    [Description("Дата и время")]
    DateTime = 7,
    [Description("Гиперссылка")]
    Hyperlink = 8,
}
public class ScalarEntityProperty : EntityProperty
{
    public ScalarValueType ValueType { get; set; }
}