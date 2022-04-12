using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Constructor.Data;
public class BaseEntity
{
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar")]
    [MaxLength(100)]
    [StringLength(100)]
    public string Name { get; set; }

    [Column(TypeName = "varchar")]
    [MaxLength(50)]
    [StringLength(50)]
    public string? Code { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    public bool IsNew => Id == 0;
}