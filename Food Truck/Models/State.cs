using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Food_Truck.Models
{
    public class State
    {
        [Key]

        public int ID { get; set; }
        [Display(Name = "State")]
        public string Name { get; set; }
    }
}