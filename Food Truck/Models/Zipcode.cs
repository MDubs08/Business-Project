using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Food_Truck.Models
{
    public class Zipcode
    {
        [Key]
        
        public int ID { get; set; }
        [Display(Name = "Zipcode")]
        public string Number { get; set; }
    }
}