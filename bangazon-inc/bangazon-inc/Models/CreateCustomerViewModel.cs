using System.ComponentModel.DataAnnotations;

namespace bangazon_inc.Models
{
    public class CreateCustomerViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required, StringLength(5)]
        public string ZipCode { get; set; }
    }
}