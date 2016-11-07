using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Food_Truck.Models
{
    public class TruckInventory
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Truck Inventory")]
        public int Quantity { get; set; }

        [ForeignKey("Inventory")]
        public int InventoryID { get; set; }
        public Inventory Inventory { get; set; }

        [ForeignKey("Truck")]
        public int TruckID { get; set; }
        public virtual Truck Truck { get; set; }
    }
}