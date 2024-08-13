using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_ban_do_an.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ICollection<Invoice> Invoices { get; set; }

        [StringLength(100, MinimumLength = 5)]
        public string? Name { get; set; } = string.Empty;

        public string? imageUrl { get; set; }

        public int? age { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(100, MinimumLength = 5)]
        public string? Email { get; set; } = string.Empty;

        public string? Phone { get; set; } = string.Empty;

        [MaxLength(30)]
        public string? contry { get; set; } = string.Empty;

        [Required]
        public int AccountCusId { get; set; }
        public AccountCus AccountCus { get; set; }

        
    }
}
