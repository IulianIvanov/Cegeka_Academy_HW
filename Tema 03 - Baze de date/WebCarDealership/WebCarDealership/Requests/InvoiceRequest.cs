using System.ComponentModel.DataAnnotations;

namespace WebCarDealership.Requests
{
    public class InvoiceRequest
    {
        [Required]
        public int InvoiceId { get; set; }
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public string InvoiceNumber { get; set; }

        [Range(1, 100)]
        public decimal Amount { get; set; }
    }
}