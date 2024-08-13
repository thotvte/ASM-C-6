using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace web_ban_do_an.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
      
        public string? Name { get; set; }

        public decimal? Price { get; set; }

        public string? Description { get; set; }

        public int? status { get; set; } = 0;

        public string? imageUrl {  get; set; }

        public DateTime createdAt { get; set; }=DateTime.Now;
        public DateTime? updatedAt { get; set;}
        public DateTime? deletedAt { get; set; }

        public ICollection<ProductItemProduct>? productItemProducts { get; set; }

    }
}
