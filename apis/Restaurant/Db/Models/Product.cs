using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Db.Models;

[Table("products")]
public class Product
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(0, 9999)]
    public double UnitPrice { get; set; } = 0;

    [Required]
    public string Image { get; set; } = string.Empty;

    [StringLength(255)]
    public string? Description { get; set; }


    #region Relationship config
    public Guid CategoryId { get; set; }

    public ICollection<ProductDiscount> ProductDiscount { get; set; } = [];

    public ICollection<ComboDetails> ComboDetails { get; set; } = [];

    #endregion
}