using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Db.Models;

[Table("orders")]
public class Order
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public DateTime OrderTime { get; set; }

    [Required]
    [StringLength(450)]
    public string Address { get; set; } = string.Empty;

    [Required]
    [Range(0, 999999)]
    public double SubTotal { get; set;} = 0;

    [Required]
    [Range(0, 999999)]
    public double Discount { get; set; } = 0;

    [Required]
    [Range(0, 999999)]
    public double Total { get; set; } = 0;

    [StringLength(255)]
    public string? Note { get; set; }

    [Required]
    [Range(0, 2)]
    public int DeliveryStatus = 0;

    [Required]
    [Range(0, 1)]
    public int PaymentStatus = 0;

    [Required]
    [Column(TypeName = "Bit")]
    public bool IsCanceled = false;


    #region  Relationship config
    public ICollection<OrderDetails> OrderDetails { get; set; } = [];

    public Guid? CustomerId { get; set; }

    #endregion
}