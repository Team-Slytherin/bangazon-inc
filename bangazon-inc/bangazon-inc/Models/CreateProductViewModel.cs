using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bangazon_inc.Models
{
    public class CreateProductViewModel
    {
        //[DisplayName("Number of People Eating Duck")]
        //public int NumberOfPeople { get; set; }
        [DisplayName("Which ProductViewId")]
        [Key]
        public int ProductViewId { get; set; }

        public virtual Product Product { get; set; }
        [DisplayName("Which Category")]
        public List<SelectListItem> Categories { get; set; }
        [DisplayName("Which Customer")]
        public List<SelectListItem> Customers { get; set; }

    }
}