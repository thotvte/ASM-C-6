using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web_ban_do_an.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ICollection<Invoice> invoices { get; set; }

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
        public int AccountEmpId { get; set; }
        public AccountEmp AccountEmp { get; set; }

        
    }
}
