using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Db.Models;

[Table("discounts")]
public class ProductDiscount
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    [Required]
    [Range(0, 100)]
    public int PercentValue { get; set; } = 5;

    [Required]
    [Range(0, 9999)]
    public double HardValue { get; set; } = 0;


    #region Relationship config
    public Guid ProductId { get; set; }

    #endregion
}