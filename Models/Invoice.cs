using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_ban_do_an.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public float total {  get; set; }

        public int status { get; set; }

        public DateTime createdAt { get; set; }= DateTime.Now;
        public DateTime? updatedAt { get; set; }

        public ICollection<InvoiceDetails> invoiceDetails {  get; set; }

        public int employeeId { get; set; }
        public Employee employee { get; set; }

        public int customerId { get; set; }
        public Customer customer { get; set; }

    }
}
