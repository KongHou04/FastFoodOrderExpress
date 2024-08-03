using System.ComponentModel.DataAnnotations;

namespace admin.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }


        #region Relationship config
        public ICollection<Product> Products { get; set; } = new List<Product>();

        #endregion
    }
}
