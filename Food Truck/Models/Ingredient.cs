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

        [ForeignKey("Food_Item")]
        public int Food_ItemID { get; set; }
        public virtual Food_Item Food_Item { get; set; }
    }
}