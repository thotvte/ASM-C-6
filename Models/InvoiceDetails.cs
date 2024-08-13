using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_ban_do_an.Models
{
    public class InvoiceDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public string Name { get; set; }

        public decimal Price { get; set; }


        public int quantity { get; set; }

        public float total {  get; set; }

        public DateTime createdAt { get; set; }= DateTime.Now;

        public DateTime? updatedAt { get; set; }

        public int invoiceId { get; set; }
        public Invoice Invoice { get; set; }

    }
}
