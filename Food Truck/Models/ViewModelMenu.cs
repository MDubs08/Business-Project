using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Food_Truck.Models
{
    public class ViewModelMenu
    {
        public string Name { get; set; }

        [ForeignKey("Menu_Item")]
        public int Menu_ItemID { get; set; }
        public Menu_Item Menu_Item { get; set; }

        [ForeignKey("OrderDetail")]
        public int OrderDetailID { get; set; }
        public OrderDetail OrderDetail { get; set; }
    }
}