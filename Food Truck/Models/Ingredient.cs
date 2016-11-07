using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Food_Truck.Models
{
    public class Ingredient
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Inventory")]
        public int InventoryID { get; set; }
        public virtual Inventory Inventory { get; set; }

        [ForeignKey("Menu_Item")]
        public int Menu_ItemID { get; set; }
        public virtual Menu_Item Menu_Item { get; set; }
    }
}