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
        [Display(Name = "Item name")]
        public string Name { get; set; }
        [Display(Name = "Sale Price")]
        public decimal Sale_Price { get; set; }

        [ForeignKey("Menu")]
        public int MenuID { get; set; }
        public Menu Menu { get; set; }
    }
}