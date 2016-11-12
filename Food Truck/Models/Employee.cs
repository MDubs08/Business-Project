using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Food_Truck.Models
{
    public class Employee
    {
        [Key]

        public int ID { get; set; }
       // [Display(Name = "Employee Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
       // [Display (Name = "Email Address")]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string AssignedPassword { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("Truck")]
        public int TruckId { get; set; }
        public Truck Truck { get; set; }
    }
}