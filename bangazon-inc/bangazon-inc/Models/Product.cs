using System.ComponentModel.DataAnnotations;

namespace bangazon_inc.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public virtual Category Category  { get; set; }  
        [MaxLength(255)]
        public string Description { get; set; }
        public string Image { get; set; }
        public virtual Customer Customer { get; set; }
    }
}