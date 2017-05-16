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
        [DisplayName("Which ProductViewId")]
        [Key]
        public int ProductViewId { get; set; }
        [DisplayName("Which Category")]
        public List<SelectListItem> Categories { get; set; }
        [DisplayName("Which Customer")]
        public List<SelectListItem> Customers { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public string Image { get; set; }

    }
}