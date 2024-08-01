using System.ComponentModel.DataAnnotations;

namespace admin.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Description { get; set; }


        #region Relationship config
        public ICollection<Product> Products { get; set; }

        #endregion
    }
}
