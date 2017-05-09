using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace bangazon_inc.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public virtual Customer Customer { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Category  { get; set; }  
        [MaxLength(255)]
        public string Description { get; set; }
        public string Image { get; set; }
    }
}