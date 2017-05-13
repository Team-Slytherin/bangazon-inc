using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bangazon_inc.Models
{
    public class Category
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}