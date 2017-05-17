using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bangazon_inc.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        public string PaymentName { get; set; }
        [Required]
        public int PaymentAccountNumber { get; set; }

        public virtual Customer Customer { get; set; }
    }
}