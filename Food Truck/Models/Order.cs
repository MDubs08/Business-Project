using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Food_Truck.Models
{
    public class Order
    {
        [Key]

        public int ID { get; set; }
        [Display(Name = "Order Date")]
        public DateTime Date { get; set; }

        [ForeignKey("Truck")]
        public int TruckID { get; set; }
        public virtual Truck Truck { get; set; }
    }
}