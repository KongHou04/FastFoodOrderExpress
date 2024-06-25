using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Db.Models;

[Table("combodetails")]
public class ComboDetails
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Range(1, 999)]
    public int Quantity { get; set; } = 1;


    #region Relationship config
    public Guid ComboId { get; set; }

    public Guid ProductId { get; set; }
    public Product? Product{ get; set; }

    #endregion
}