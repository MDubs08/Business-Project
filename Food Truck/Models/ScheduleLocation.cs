using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Food_Truck.Models
{
    public class ScheduleLocation
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Truck")]
        public int TruckID { get; set; }
        public Truck Truck { get; set; }

        [ForeignKey("Location")]
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }

        [ForeignKey("Schedule")]
        public int ScheduleID { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}