using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bangazon_inc.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerFirstName { get; set; }
        [Required]
        public string CustomerLastName { get; set; }
        [Required]
        public string CustomerAddressLine1 { get; set; }
        public string CustomerAddressLine2 { get; set; }
        [Required]
        public string CustomerCity { get; set; }
        [Required]
        public string CustomerState { get; set; }
        [Required, StringLength(5)]
        public string CustomerZipCode { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<Payment> Payments { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}