using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarHire.Models.Vehicles
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using CarHire.Models.Base_Classes;

    public class Manufacturer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ManufacturerId { get; set; }

        public Manufacturer() { }

        public Manufacturer(string manufacturerName)
        {
            this.ManufacturerName = manufacturerName;
        }

        [Required]
        public string ManufacturerName { get; set; }

        //public virtual ICollection<Vehicle> Models { get; set; }
    }
}