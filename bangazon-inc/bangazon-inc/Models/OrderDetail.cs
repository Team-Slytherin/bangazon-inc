﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace bangazon_inc.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product{ get; set; }
    }
}