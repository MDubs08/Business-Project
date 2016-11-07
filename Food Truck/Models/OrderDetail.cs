using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Food_Truck.Models
{
    public class OrderDetail
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Order Quantity")]
        public int Quantity { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public Order Order { get; set; }

        [ForeignKey("Menu_Item")]
        public int Menu_ItemID { get; set; }
        public virtual Menu_Item Menu_Item { get; set; }
    }
}