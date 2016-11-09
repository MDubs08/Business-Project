using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Food_Truck.Models
{
    public class Menu_Item
    {
        [Key]

        public int ID { get; set; }

        [ForeignKey("Food_Item")]
        public int Food_ItemID { get; set; }
        public virtual Food_Item Food_Item { get; set; }

        [ForeignKey("Menu")]
        public int MenuID { get; set; }
        public virtual Menu Menu { get; set; }
    }
}