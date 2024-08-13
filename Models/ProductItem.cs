using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace web_ban_do_an.Models
{
    public class ProductItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        public string? stock {  get; set; }

        [MaxLength(100)]
        public int? rating { get; set; }


        public string? imageUrl { get; set; }

        public DateTime createdAt { get; set; }= DateTime.Now;
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt {  get; set; }

        [Required]
        public int categoryId { get; set; }
        public Category category { get; set; }

        public ICollection<ProductItemProduct> productItemProducts { get; set; }

    }
}
