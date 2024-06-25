using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Db.Models;

[Table("orderdetails")]
public class OrderDetails
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    [Range(0, 9999)]
    public double UnitPrice { get; set; } = 0;

    [Required]
    [Range(1, 999)]
    public int Quantity { get; set; } = 1;

    [StringLength(255)]
    public string? Note { get; set; }


    #region Relationship config
    public Guid OrderId { get; set; }

    public Guid? ProductId { get; set; }
    public Product? Product { get; set; }

    #endregion
}