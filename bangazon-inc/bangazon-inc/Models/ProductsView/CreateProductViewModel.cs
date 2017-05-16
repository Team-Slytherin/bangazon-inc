using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bangazon_inc.Models.ProductsView
{
    public class CreateProductViewModel
    {
        [DisplayName("Product Name")]
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public int CustomerId { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Customers { get; set; }

    }
}