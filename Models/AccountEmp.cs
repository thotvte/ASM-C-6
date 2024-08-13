using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web_ban_do_an.Models
{
    public class AccountEmp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string UserName { get; set; }

        [MaxLength(20)]
        [Required]
        public string Password { get; set; }

        [MaxLength(20)]
        [Required]
        public string Email { get; set; } = string.Empty;

        public DateTime createdAt { get; set; } = DateTime.Now;
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt { get; set; }

        [Required]
        public int roleId { get; set; }
        public Role role { get; set; }

        public Employee employee { get; set; }
    }
}
