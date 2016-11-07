using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Food_Truck.Models
{
    public class Inventory
    {
        [Key]
        
        public int ID { get; set; }
        public string Name { get; set; }
        [Display(Name = "Purchase Price")]
        public decimal Purchase_Price { get; set; }
        [Display(Name = "Purchase Date")]
        public DateTime Purchase_Date { get; set; }
        [Display(Name = "Quantity in stock")]
        public int QuantityInStock { get; set; }
        [Display(Name = "In stock")]
        public bool inStock { get; set; }
    }
}