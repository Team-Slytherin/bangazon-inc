using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace bangazon_inc.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public virtual Customer Customer { get; set; }
        [Required]
        public virtual Payment Payment { get; set; }
        public string OrderActive { get; set; }
    }
}