using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Food_Truck.Models
{
    public class Address
    {
        [Key]

        public int ID { get; set; }
        [Display(Name = "Street Number")]
        public int Street_Number { get; set; }
        [Display(Name = "Street Name")]
        public string Street_Name { get; set; }

        [ForeignKey("City")]
        public int CityID { get; set; }
        public City City { get; set; }

        [ForeignKey("State")]
        public int StateID { get; set; }
        public State State { get; set; }

        [ForeignKey("Zipcode")]
        public int ZipcodeID { get; set; }
        public Zipcode Zipcode { get; set; }
    }
}