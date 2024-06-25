using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Db.Models;

[Table("coupontypes")]
public class CouponType
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


    #region  Relationship config
    public ICollection<Coupon> Coupons { get; set; } = [];

    #endregion
}