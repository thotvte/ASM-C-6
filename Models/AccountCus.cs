using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_ban_do_an.Models
{
    public class AccountCus
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

        public Customer customer { get; set; }


    }
}
