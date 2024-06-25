using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Db.Models;

[Table("customer")]
public class Customer
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;

    [StringLength(10)]
    [RegularExpression(@"[0-9]")]
    public string? Phone { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;


    #region Relationship config
    public ICollection<Order> Orders { get; set; } = [];

    public ICollection<Coupon> Coupons { get; set; } = [];

    #endregion
}