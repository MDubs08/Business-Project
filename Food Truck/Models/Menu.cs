using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Food_Truck.Models
{
    public class Menu
    {
        [Key]

        public int ID { get; set; }
        public string Name { get; set; }
    }
}