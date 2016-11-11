using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Food_Truck.Models
{
    public class Food_Item
    {
        [Key]

        public int ID { get; set; }
        [Display(Name = "Item Name")]
        public string Name { get; set; }
        [Display(Name = "Sale Price")]
        public decimal Sale_Price { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}